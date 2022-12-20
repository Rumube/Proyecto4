using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WormManager : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public Transform _holeLocation;

    WormManager _wormHole;
    public GameObject _destiny;

    
    bool _whole = true;
    CinemachineFreeLook _cinemachine;
    
    
    void Start()
    {
       _wormHole= GameObject.FindGameObjectWithTag("WormHole").GetComponentInChildren<WormManager>();
       _holeLocation = GameObject.FindGameObjectWithTag("WormHole").transform.GetChild(0).gameObject.transform;
       _cinemachine = GameObject.FindGameObjectWithTag("FreeLook").GetComponent<CinemachineFreeLook>();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            //_whole=!_whole;
            collision.gameObject.transform.position = _holeLocation.position;
            StartCoroutine("Enable");
            if (_whole==true)
            {
                _cinemachine.m_Lens.FieldOfView = 179;
                _whole = false;
            }
            else
            {
                Debug.Log("hola");
                _cinemachine.m_Lens.FieldOfView = 40;
            }
            _wormHole._holeLocation= _destiny.transform;
        }
    }
    IEnumerator Enable()
    {
        _destiny.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5f);
        _destiny.GetComponent<Collider>().enabled = true;
    }
}
