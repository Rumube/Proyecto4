using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
   public Animator animator;
    bool Left;
    //private bool left = Animator.
        
    private Transform _transform;
    private Rigidbody _rb;

    //speed
    public float _turnSpeed = 60;
    public float _boostSpeed = 5f;




    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _transform = GetComponent<Transform>();
        Left = false;
    }

    private void FixedUpdate()
    {
        Turn();
        MoveUpdate();
        Animation();
    }

    private void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = _turnSpeed * Time.deltaTime * -Input.GetAxis("Vertical");
        float roll = _turnSpeed * Time.deltaTime * Input.GetAxis("Rotate");
        _transform.Rotate(pitch, yaw, roll);
    }

    private void Animation()
    {
        //A
        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
        //D
        if (Input.GetAxis("Horizontal") > 0) 
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        //W 
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }
        //S
        if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("Down", true);
        }
        else
        {
            animator.SetBool("Down", false);
        }





    }

    private void MoveUpdate()
    {
        _transform.position += _transform.forward * _boostSpeed * Time.deltaTime;
    }

    //GETTERS
    public float GetTurnSpeed()
    {
        return _turnSpeed;
    }
    public float GetBoostSpeed()
    {
        return _boostSpeed;
    }

    //SETTERS
    public void SetTurnSpeed(float newValue)
    {
        _turnSpeed = newValue;
    }
    public void SetboostSpeed(float newValue)
    {
        _boostSpeed = newValue;
    }
}
