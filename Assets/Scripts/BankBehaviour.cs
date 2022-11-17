using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    Vector3 newposition;
    Vector3 direccion;
    public Vector3 targetVec;
    
    public float velocidad;
    bool moviendose = true;
 
    
    public Rigidbody luciernaga;


    private IEnumerator coroutine;

    void Start()
    {
        luciernaga = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Volar();
        if (Input.GetKey(KeyCode.Space))
        {
            float distance = Vector3.Distance(transform.position, target.position);
            transform.position = Vector3.Lerp(transform.position, target.position, velocidad);
           

        }
        else
        {
            if (moviendose == true)
            {
                direccion = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

                luciernaga.velocity = transform.TransformDirection(velocidad * direccion);
                luciernaga.angularVelocity = transform.TransformDirection(velocidad * direccion);


                coroutine = Movimiento(1f);

                StartCoroutine(coroutine);
            }
        }

    }
   
    private IEnumerator Movimiento(float waitTime)
    {
        moviendose = false;
        yield return new WaitForSeconds(waitTime);
        moviendose = true;
    }
    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("collision");
        //luciernaga.velocity = transform.TransformDirection(velocidad * direccion * -1);
        //luciernaga.angularVelocity = transform.TransformDirection(velocidad * direccion * -1);
        //coroutine = Movimiento(1f);

        //StartCoroutine(coroutine);


    }

   

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
