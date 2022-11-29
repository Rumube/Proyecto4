using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoidSettings : ScriptableObject {
    // Settings
    public float minSpeed = 2;
    public float maxSpeed = 5;
    public float perceptionRadius = 2.5f;//2.5f
    public float avoidanceRadius = 1;//1
    public float maxSteerForce = 3;//3

    public float alignWeight = 1;
    public float cohesionWeight = 1;
    public float seperateWeight = 1;

    public float targetWeight = 10;//original 1

    [Header ("Collisions")]
    public LayerMask obstacleMask;
    public float boundsRadius = 5f;//.27
    public float avoidCollisionWeight = 100;//10
    public float collisionAvoidDst = 30;//5

}