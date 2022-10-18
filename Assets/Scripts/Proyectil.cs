using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    //Parameters
    [Header("Parameters")]
    public float _initVelocity;
    public float _followVelocity;
    public float _initTime;

    private GameObject _target;
    private Vector3 _direction;
    private float _finishInitTime;

    public enum ProyectilStatus
    {
        init,
        follow
    }
    public ProyectilStatus _proyectilStatus;

    // Start is called before the first frame update
    void Start()
    {
        _finishInitTime = Time.realtimeSinceStartup + _initTime;
        _proyectilStatus = ProyectilStatus.init;
        _direction = Random.insideUnitSphere;
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (_proyectilStatus)
        {
            case ProyectilStatus.init:
                InitMovement();
                if(Time.realtimeSinceStartup >= _finishInitTime)
                {
                    _proyectilStatus = ProyectilStatus.follow;
                }
                break;
            case ProyectilStatus.follow:
                FollowMovement();
                break;
            default:
                break;
        }
    }

    private void FollowMovement()
    {
        transform.LookAt(_target.transform);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _followVelocity);
    }

    private void InitMovement()
    {
        transform.position += _direction * _initVelocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger: " + other.name);
        if(other.tag == "Player")
        {
            other.GetComponent<Whale>().LightDown();
            Camera.main.GetComponent<CameraShake>().Shake(0.3f, 10);
            Destroy(gameObject);
        }
    }
}
