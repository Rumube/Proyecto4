using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystem : MonoBehaviour
{
    [Header("Prefences")]
    public float _rangeDetection;
    public bool _hasCivilization;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector3.Distance(_player.transform.position, transform.position) <= _rangeDetection)
        {
            print("Cetus Detectado: " + this.gameObject);
        }
    }

}
