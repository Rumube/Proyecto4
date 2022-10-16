using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : SpaceObject
{
    public enum StarType
    {
        Azul,
        Blanco,
        Amarillo,
        Naranja,
        Roja
    }
    [Header("Stats")]
    public StarType _starType;
    public int _numPlanets;

    #region References
    [Header("References")]
    public List<GameObject> _planets  = new List<GameObject>();
    public List<GameObject> _planetPositions = new List<GameObject>();
    public List<Material> _starMaterials = new List<Material>();
    public GameObject _orbit;
    System.Random _rng;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitValues()
    {
        _numPlanets = _rng.Next(1, 5);
        _starType = (StarType)_rng.Next(0,5);
        GetComponent<Renderer>().material = _starMaterials[(int)_starType];
        for (int i = 0; i < _numPlanets; i++)
        {
            int randomIndex = _rng.Next(0, _planets.Count);
            GameObject newPlanet = Instantiate(_planets[randomIndex], transform);
            newPlanet.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            newPlanet.transform.position = _planetPositions[i].transform.position;
        }

        float angx = _rng.Next(0, 360);
        float angy = _rng.Next(0, 360);
        float angz = _rng.Next(0, 360);

        _orbit.transform.rotation = Quaternion.Euler(angx, angy, angz);

    }

    public void SetRng(System.Random value)
    {
        _rng = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
