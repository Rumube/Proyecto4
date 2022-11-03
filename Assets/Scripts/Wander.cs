using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float _speedMove;
    public float _speedRotation;
    Vector3 _randomVector;
    bool _spin=true;
    bool _wander=true;


    public int _rotationX;
    public int _rotationY;
    public int _rotationZ;
    // Start is called before the first frame update
    void Start()
    {
        _randomVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-2, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (_wander==true)
        {
            transform.Rotate(_randomVector * _speedRotation * Time.deltaTime);
            transform.position += (transform.forward * _speedMove * Time.deltaTime);

            transform.Rotate(_randomVector * _speedRotation * Time.deltaTime);
            if (_spin == true)
            {
                _randomVector = new Vector3(Random.Range(-_rotationX, _rotationX + 1), Random.Range(-_rotationY, _rotationY + 1), Random.Range(-_rotationZ, _rotationZ + 1));

                StartCoroutine("SpinTime");
                _spin = false;


            }
        }
        else
        {
           
            if (_randomVector==Vector3.zero)
            {
                transform.position += (transform.forward * -_speedMove * Time.deltaTime);
            }
            else
            {
                transform.Rotate(-_randomVector * (_speedRotation + 100) * Time.deltaTime);
                transform.position += (transform.forward * _speedMove * Time.deltaTime);
            }
            
        }
        
      
    }
    void Spin()
    {

    }
    IEnumerator SpinTime()
    { 
        yield return new WaitForSeconds(2);
        _spin = true;

    }
    private void OnCollisionStay(Collision collision)
    {
        _wander = false;
        

    }
    private void OnCollisionExit(Collision collision)
    {
        _wander = true;
    }
}