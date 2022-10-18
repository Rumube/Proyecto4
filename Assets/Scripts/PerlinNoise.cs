using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{

    /*CONFIGURACIÓN
     0.14
     25
     0.3
     */

    public enum SpaceObjects
    {
        SolarSystem,
        BlackHole
    }

    private GameObject _ship;
    [Header("References")]
    public GameObject _spaceObject;
    public GameObject _ChargeRock;

    [Header("Game Parameters")]
    public int _seed = 0;
    public float scale = 1.0F;
    public int _range;
    public float _spawnRate;
    public Vector3 _lastPos;
    public float _chanceChargeRock;
    public float _timeToUpdate;
    public int _rangeMultiplier;

    float _nextUpdate;
    System.Random _rng;
    void Start()
    {
        _ship = GameObject.FindGameObjectWithTag("Player");
        StartGenerateWorld();
    }

    public void StartGenerateWorld()
    {
        _nextUpdate = Time.realtimeSinceStartup + _timeToUpdate;
        _rng = new System.Random(_seed);
        CalcNoise();
    }

    private void CalcNoise()
    {

        //X LIMIT
        float xLimitSup;
        float xLimitInf;
        //Y LIMIT
        float yLimitSup;
        float yLimitInf;
        //Z LIMIT
        float zLimitSup;
        float zLimitInf;

        //X LIMIT
        xLimitSup = CalculateLimit((int)_ship.transform.position.x, true);
        xLimitInf = CalculateLimit((int)_ship.transform.position.x, false);
        //Y LIMIT
        yLimitSup = CalculateLimit((int)_ship.transform.position.y, true);
        yLimitInf = CalculateLimit((int)_ship.transform.position.y, false);
        //Z LIMIT
        zLimitSup = CalculateLimit((int)_ship.transform.position.z, true);
        zLimitInf = CalculateLimit((int)_ship.transform.position.z, false);

        for (int x = (int)xLimitInf; x <= (int)xLimitSup; x += _rangeMultiplier)
        {
            for (int y = (int)yLimitInf; y <= (int)yLimitSup; y += _rangeMultiplier)
            {
                for (int z = (int)zLimitInf; z <= (int)zLimitSup; z += _rangeMultiplier)
                {
                    if (Perlin3D(x, y, z) <= _spawnRate)
                    {
                        GameObject newObject;

                        newObject = Instantiate(_spaceObject, transform);
                        newObject.transform.position = new Vector3(x, y, z);
                        newObject.GetComponent<SolarSystem>().SetRng(_rng);
                        newObject.GetComponent<SolarSystem>().InitValues();
                    }
                }
            }
        }
        _lastPos = _ship.transform.localPosition;
    }

    private int CalculateLimit(int value, bool isAdd)
    {
        int limit = 0;
        if (isAdd)
        {
            limit = value + _range;
            while (limit % _rangeMultiplier != 0)
            {
                limit++;
            }
        }
        else
        {
            limit = value - _range;
            while (limit % _rangeMultiplier != 0)
            {
                limit--;
            }
        }
        return limit;
    }

    public float Perlin3D(float x, float y, float z)
    {
        x *= scale;
        y *= scale;
        z *= scale;

        float AB = Mathf.PerlinNoise(x, y);
        float BC = Mathf.PerlinNoise(y, z);
        float AC = Mathf.PerlinNoise(x, z);

        float BA = Mathf.PerlinNoise(y, x);
        float CB = Mathf.PerlinNoise(z, y);
        float CA = Mathf.PerlinNoise(z, x);

        float ABC = AB + BC + AC + BA + CB + CA;
        return ABC / 6f;

    }


    void Update()
    {
        if (NeedUpdate())
        {
            UpdateSpace();
        }
    }

    bool NeedUpdate()
    {
        bool result = false;

        //X LIMIT
        float xLimitSup = _lastPos.x + (_range / 2);
        float xLimitInf = _lastPos.x - (_range / 2);
        //Y LIMIT
        float yLimitSup = _lastPos.y + (_range / 2);
        float yLimitInf = _lastPos.y - (_range / 2);
        //Z LIMIT
        float zLimitSup = _lastPos.z + (_range / 2);
        float zLimitInf = _lastPos.z - (_range / 2);
        Vector3 currentPos = _ship.transform.position;
        if (currentPos.x >= xLimitSup || currentPos.x <= xLimitInf || currentPos.y >= yLimitSup || currentPos.y <= yLimitInf || currentPos.z >= zLimitSup || currentPos.z <= zLimitInf)
            result = true;


        if (Time.realtimeSinceStartup >= _nextUpdate)
        {
            result = true;
            _nextUpdate = Time.realtimeSinceStartup + _timeToUpdate;
        }
        return result;
    }

    void DestroyAllSpaceObjects()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("SpaceObject");
        foreach (GameObject currentAsteroid in asteroids)
        {
            Destroy(currentAsteroid);
        }
    }

    void UpdateSpace()
    {
        DestroyAllSpaceObjects();
        CalcNoise();
    }
}
