using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystem : MonoBehaviour
{
    [Header("Prefences")]
    public GameObject _proyectil;
    public float _proyectilCooldown;
    public float _rangeDetection;
    public bool _hasCivilization;
    private GameObject _player;
    private float _nextProyectil;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _nextProyectil = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector3.Distance(_player.transform.position, transform.position) <= _rangeDetection && _hasCivilization && Time.realtimeSinceStartup >= _nextProyectil)
        {
            _nextProyectil = Time.realtimeSinceStartup + _proyectilCooldown;
            Instantiate(_proyectil, transform);
            print("Cetus Detectado: " + this.gameObject);
        }
    }

}
