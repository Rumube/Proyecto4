using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedMemory : SpaceObject
{
    [Header("Mesh")]
    [SerializeField]
    private List<Mesh> _meshList;
    private MeshFilter _meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        SetMesh();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sets the memory mesh
    /// </summary>
    private void SetMesh()
    {
        int randomMesh = Random.Range(0, _meshList.Count);
        _meshFilter.sharedMesh = _meshList[randomMesh];
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Whale>().GetCompass().MemoriesUp();
            Destroy(gameObject);
        }
    }
}
