using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trabajo : Build
{
    public int _materialGenerated;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _materialGenerated = _currentOcupation;
    }
}
