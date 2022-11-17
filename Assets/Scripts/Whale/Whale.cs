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

    #region Lights
    //public void RestartLife()
    //{
    //    _currentLifePoints = _maxLifePoints;
    //    UpdateLights();
    //}

    //public void LightDown()
    //{
    //    _currentLifePoints--;
    //    if( _currentLifePoints <= 0)
    //    {
    //        _currentLifePoints = 0;
    //        print("Has perdido");
    //    }
    //    UpdateLights();
    //}

    //public void LightUp()
    //{
    //    _currentLifePoints++;
    //    if( _currentLifePoints >= 6)
    //    {
    //        _currentLifePoints = _maxLifePoints;
    //    }
    //    UpdateLights();
    //}

    //private void UpdateLights()
    //{
    //    foreach (GameObject light in _lightsList)
    //    {
    //        light.GetComponent<Renderer>().material = _lowStar;
    //    }

    //    float newTurnSpeed = 0f;
    //    float newBoostSpeed = 0f;

    //    for (int i = 0; i < _currentLifePoints; i++)
    //    {
    //        _lightsList[i].GetComponent<Renderer>().material = _highStar;
    //        newTurnSpeed += 20f;
    //        newBoostSpeed += 4f;
    //    }

    //    _controller.SetTurnSpeed(newTurnSpeed);
    //    _controller.SetboostSpeed(newBoostSpeed);
    //}
    #endregion
    private void OnTriggerEnter(Collider other)
    {

    }

    public Compass GetCompass()
    {
        return _compass;
    }
}
