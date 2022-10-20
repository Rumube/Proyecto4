using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health = 30;
    float maxLife;
    public Image healthBar;
    public GameObject player;
    void Start()
    {
        maxLife = health;
    }

    // Update is called once per frame
    void Update()
    {
      //  Vector3 target = (0f, player.transform.position, 0f);
       // transform.LookAt(player.transform);
       // transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
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
