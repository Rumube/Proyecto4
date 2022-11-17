using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [Header("Configuration")]
    public Vector3 _base;

    [Header("Stats")]
    public int _currentMemories;

    [Header("References")]
    public List<GameObject> _memoryParticle = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MemoriesUp()
    {
        _currentMemories++;

        int randomParticle = Random.Range(0, _memoryParticle.Count);
        GameObject newMemory = Instantiate(_memoryParticle[randomParticle], transform);
        newMemory.GetComponent<Memory>().SetTarge(_base);
    }

    public void MemoriesDown()
    {
        _currentMemories--;
    }

}
