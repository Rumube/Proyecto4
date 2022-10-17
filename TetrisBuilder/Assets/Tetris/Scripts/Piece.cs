using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private bool _isFall = true;
    private float _nextMove = 0f;
    private int _lastX = 0;
    private Rigidbody _rigidbody;
    private TetrisController _tetrisController;
    private Vector3 _startPosition;
    float timer = 0f;
    float quickDropTime = 0.05f;
    float dropTime = 0.9f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1 * Time.deltaTime;
        if (_isFall)
        {
            //MOVEMENT
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (transform.position.z < _startPosition.z + 1)
                {
                    transform.position += Vector3.forward;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (transform.position.z > _startPosition.z - 1)
                {
                    transform.position += Vector3.back;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                if(transform.position.x > _startPosition.x - 1)
                {
                    transform.position += Vector3.left;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x < _startPosition.x + 1)
                {
                    transform.position += Vector3.right;
                }
            }
            //ROTATION
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                int newX = _lastX - 90;
                _lastX = newX;
                transform.rotation = Quaternion.Euler(newX, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
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
        if (Input.GetKey(KeyCode.Space))
        {
            _nextMove = Time.realtimeSinceStartup + 0.4f;
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isFall && (collision.gameObject.tag == "Piece" || collision.gameObject.tag == "Ground"))
        {
            _isFall = false;
            _rigidbody.isKinematic = true;
            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y+1), Mathf.Round(transform.position.z));
            _tetrisController.GetCurrentBuild().AddPiece(gameObject);
            _tetrisController.CreatePiece();
        }
    }

    public void SetTetrisController(TetrisController tetris)
    {
        _tetrisController = tetris;
    }
}
