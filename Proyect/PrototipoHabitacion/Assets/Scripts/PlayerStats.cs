using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health=100;
    float maxLife;
    public  GameObject sword;
    public GameObject shield;
    bool hasShield;
    bool hasSword;
    bool shieldOn;
    public Animator anim;
    public Image healthBar;
    void Start()
    {
        maxLife = health;
        hasShield = false;
        hasSword = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health/ maxLife;
        if (hasShield==true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (shieldOn == true)
                {
                    shield.SetActive(false);
                    shieldOn = false;
                }
                else
                {
                    shield.SetActive(true);
                    shieldOn = true;
                }
               
            }
            
        }
        if (hasSword == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                anim.SetBool("Attacking", true);

            }
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                anim.SetBool("Attacking", false);

            }

        }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            sword.SetActive(true);
            hasSword = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Shield"))
        {
            shield.SetActive(true);
            shieldOn = true;
            hasShield =true;
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            if (shieldOn==true)
            {
                health -= 1;
            }
            else
            {
                health -= 10;
            }
            
        }
        else if (collision.gameObject.CompareTag("Curandero"))
        {
            health = maxLife;
        }
        else if(collision.gameObject.CompareTag("Door"))
        {
            StartCoroutine(Door(collision.gameObject));
        }
    }
    IEnumerator Door(GameObject door)
    {
        door.SetActive(false);
         yield return new WaitForSeconds(3f);
        door.SetActive(true);
    }
}
