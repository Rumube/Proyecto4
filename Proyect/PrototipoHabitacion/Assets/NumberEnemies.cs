using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberEnemies : MonoBehaviour
{
    public RotateRoom1 rotateRoom1;
    public GameObject enemies;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateRoom1.counter==0)
        {
            enemy.SetActive(false);
            enemies.SetActive(true);
        }
        else
        {
            enemy.SetActive(true);
            enemies.SetActive(false);
        }
    }
}
