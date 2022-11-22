using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    #region Stats
    [Header("Stats")]
    public int _currentLifePoints;
    public int _maxLifePoints;
    public int _currentMemories = 0;
    #endregion

    #region References
    [Header("References")]
    public GameObject _memoryParticle;
    private Controller _controller;
    public Compass _compass;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

    }

    public Compass GetCompass()
    {
        return _compass;
    }
}
