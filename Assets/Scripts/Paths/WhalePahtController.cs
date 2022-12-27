using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class WhalePahtController : MonoBehaviour
{
    public PathCreator _pathcreator;
    public float _speed = 150;
    float _distanceTravelled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        transform.position = _pathcreator.path.GetPointAtDistance(_distanceTravelled);
        transform.rotation = _pathcreator.path.GetRotationAtDistance(_distanceTravelled);
    }
}
