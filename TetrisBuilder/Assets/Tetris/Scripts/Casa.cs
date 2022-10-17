using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casa : Build
{
    public List<GameObject> _citizenList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCitizens()
    {
        for (int i = 0; i < _currentOcupation; i++)
        {
            int random = Random.Range(0, _citizenList.Count);
            GameObject newCitizen = Instantiate(_citizenList[random]);
        }
    }

}
