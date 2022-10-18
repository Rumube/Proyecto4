using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 30;
    float maxLife;
    public Image healthBar;
    void Start()
    {
        maxLife = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxLife;
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            health -= 10;
        }
    }
   
}
