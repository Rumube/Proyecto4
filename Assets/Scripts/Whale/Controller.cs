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
    public float _impulseTime;
    public float _impulseCooldown;

    //Controls
    private float _horizontalValue;
    private float _verticalValue;
    private float _rotateValue;
    private bool _impulse;
    private bool _sonar;
    private float _stopImpulse;
    private float _nextImpulse = 0;

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

    }

    private void Update()
    {
        InputUpdate();
        Turn();
        MoveUpdate();
        Animation();
    }


    private void InputUpdate()
    {
        _horizontalValue = Input.GetAxis("Horizontal");
        _verticalValue = Input.GetAxis("Vertical");
        _rotateValue = Input.GetAxis("Rotate");
        if (Input.GetKey(KeyCode.Space) && !_impulse)
        {
            _impulse = true;
            _stopImpulse = Time.realtimeSinceStartup + _impulseTime;   
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            ActiveSonar();
        }
    }

    private void Turn()
    {
        float yaw = _turnSpeed * Time.deltaTime * _horizontalValue;
        float pitch = _turnSpeed * Time.deltaTime * -_verticalValue;
        float roll = _turnSpeed * Time.deltaTime * _rotateValue;
        _transform.Rotate(pitch, yaw, roll);
    }

    private void Animation()
    {//SPACE
        if (Input.GetKey("space"))
        {
            animator.SetBool("Space",true);
        }
        else
        {
            animator.SetBool("Space", false);
        }

        //A
        if (_horizontalValue < 0)
        {
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Left", false);
        }
        //D
        if (_horizontalValue > 0)
        {
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Right", false);
        }
        //W 
        if (_verticalValue > 0)
        {
            animator.SetBool("Up", true);
        }
        else
        {
            animator.SetBool("Up", false);
        }
        //S
        if (_verticalValue < 0)
        {
            animator.SetBool("Down", true);
        }
        else
        {
            animator.SetBool("Down", false);
        }
    }

    private void ActiveSonar()
    {
        GetComponent<SonarController>().StartSonar();
    }

    private void MoveUpdate()
    {
        float newBoost = _boostSpeed;
        if (_impulse)
        {
            newBoost *= 10;
        }

        if(Time.realtimeSinceStartup >= _stopImpulse && _impulse)
        {
            _impulse = false;
            _nextImpulse = Time.realtimeSinceStartup + _impulseCooldown;
        }

        _transform.position += _transform.forward * newBoost * Time.deltaTime;
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
