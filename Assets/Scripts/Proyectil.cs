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
        print("Follow");
    }

    private void InitMovement()
    {
        print("Init");
    }
}
