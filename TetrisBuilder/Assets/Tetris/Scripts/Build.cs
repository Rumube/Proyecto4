using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public int _maxOcupation;
    public int _currentOcupation;
    public string _name;
    public List<GameObject> _pieces;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPiece(GameObject newPiece)
    {
        _pieces.Add(newPiece);
    }

    public void SetOcupation(int value)
    {
        if(value <= _maxOcupation)
        {
            _currentOcupation = value;
        }
    }

    public int GetOcupation()
    {
        return _currentOcupation;
    }
    public int GetMaxOcupation()
    {
        return _maxOcupation;
    }

    public string GetData()
    {
        return _name;
    }
}
