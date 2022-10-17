using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is for cube groups rotation 
 */
public class Rotation : MonoBehaviour 
{
    private bool _isFall = true;
    private float _nextMove = 0f;
    private int _lastX = 0;
    private Rigidbody _rigidbody;
    
    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFall)
        {
           
            //ROTATION
            if (Input.GetKeyDown(KeyCode.Q))
            {
                int newX = _lastX - 90;
                _lastX = newX;
                transform.rotation = Quaternion.Euler(newX, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                int newX = _lastX + 90;
                _lastX = newX;
                transform.rotation = Quaternion.Euler(newX, 90, 0);
            }

            //DOWN
            if (Time.realtimeSinceStartup >= _nextMove)
            {
                _nextMove = Time.realtimeSinceStartup + 1f;
                DownPiece();
            }
        }

    }

    private void DownPiece()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFall && (collision.gameObject.tag == "Piece" || collision.gameObject.tag == "Ground"))
        {
            _isFall = false;
            _rigidbody.isKinematic = true;
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y + 1), Mathf.Round(transform.position.z));
            
        }
    }
}
