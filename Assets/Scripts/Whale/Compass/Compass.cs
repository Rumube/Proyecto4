using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [Header("Configuration")]
    public Vector3 _base;

    [Header("Stats")]
    public int _currentMemories;
    public bool _compasActive;

    [Header("References")]
    public List<GameObject> _memoryParticle = new List<GameObject>();
    private List<GameObject> _memoriesList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Creates a new memory
    /// </summary>
    public void MemoriesUp()
    {
        _currentMemories++;

        int randomParticle = Random.Range(0, _memoryParticle.Count);
        GameObject newMemory = Instantiate(_memoryParticle[randomParticle], transform);
        newMemory.GetComponent<Memory>().SetTarge(_base);
        _memoriesList.Add(newMemory);
    }

    /// <summary>
    /// Lose 1 memory
    /// </summary>
    public void MemoriesDown()
    {
        _currentMemories--;
    }

    /// <summary>
    /// Active or disactive the compass
    /// </summary>
    public void ChangeMemoryStates()
    {
        _compasActive = !_compasActive;
        foreach (GameObject memory in _memoriesList)
        {
            if (_compasActive)
            {
                memory.GetComponent<Memory>().SetMemoryState(Memory.MemoryState.followWhave);
            }
            else
            {
                memory.GetComponent<Memory>().SetMemoryState(Memory.MemoryState.followTail);
            }
        }
    }
}
