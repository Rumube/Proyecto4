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
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFall)
        {
            //MOVEMENT
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += Vector3.down;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right;
            }
            //ROTATION
            if (Input.GetKeyDown(KeyCode.A))
            {
                int newX = _lastX - 90;
                _lastX = newX;
                transform.rotation = Quaternion.Euler(newX, 90, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
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
        if (_isFall)
        {
            _isFall = false;
            _rigidbody.isKinematic = true;
            _tetrisController.CreatePiece();
        }
    }

    public void SetTetrisController(TetrisController tetris)
    {
        _tetrisController = tetris;
    }
}
