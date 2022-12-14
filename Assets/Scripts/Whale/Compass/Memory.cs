using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    //Parameters
    [Header("Parameters")]
    public float _followVelocity;
    private Vector3 _target;
    private GameObject _whale;
    private SphereCollider _collider;

    public enum MemoryState
    {
        followNexo,
        followWhave,
        followTail
    }

    public MemoryState _memoryState;

    // Start is called before the first frame update
    void Start()
    {
        _whale = GameObject.FindGameObjectWithTag("Player");
        _collider = GetComponent<SphereCollider>();
        _collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMovement();
    }

    /// <summary>
    /// Moves the memory in the correct direction
    /// </summary>
    private void FollowMovement()
    {
        switch (_memoryState)
        {
            case MemoryState.followNexo:
                transform.position = Vector3.MoveTowards(transform.position, _target, _followVelocity * Time.deltaTime);
                break;
            case MemoryState.followWhave:
                transform.position = Vector3.MoveTowards(transform.position, _whale.transform.position, _followVelocity * Time.deltaTime);
                break;
            case MemoryState.followTail:
                transform.position = Vector3.MoveTowards(transform.position, _whale.transform.position, _followVelocity * Time.deltaTime);
                break;
            default:
                break;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(_memoryState != MemoryState.followTail)
        {
            _memoryState = MemoryState.followNexo;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (_memoryState != MemoryState.followTail)
        {
            _memoryState = MemoryState.followWhave;
        }
    }

    /// <summary>
    /// Set the base's position
    /// </summary>
    /// <param name="basePosition"></param>
    public void SetTarge(Vector3 basePosition)
    {
        _target = basePosition;
    }

    public void ChangeMemoryState(bool value)
    {

    }

    /// <summary>
    /// Set the momery state
    /// </summary>
    /// <param name="newState"></param>
    public void SetMemoryState(MemoryState newState)
    {
        _memoryState = newState;
        UpdateCollision();
    }

    /// <summary>
    /// Update the collisions and detect the memory position
    /// </summary>
    private void UpdateCollision()
    {
        _collider.enabled = false;
        _collider.enabled = true;
    }

}
