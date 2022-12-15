using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _holeLocation;
    public WormManager _teleport;
    public GameObject _destiny;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.gameObject.transform.position = _holeLocation.position;
            StartCoroutine("Enable");
          
          
            _teleport._holeLocation= _destiny.transform;
        }
    }
    IEnumerator Enable()
    {
        _destiny.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(5f);
        _destiny.GetComponent<Collider>().enabled = true;

    }
}
