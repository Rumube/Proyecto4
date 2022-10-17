using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 30;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            Destroy(this);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            health -= 10;
        }
    }
}
