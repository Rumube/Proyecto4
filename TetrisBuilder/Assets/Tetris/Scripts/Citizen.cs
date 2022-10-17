using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    // Start is called before the first frame update

    public enum State
    {
        working,
        rest,
        unemployed
    }

    public State _state = State.unemployed;

    void Start()
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public GameController _gameController;

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.working:
                break;

            case State.rest:
                break;

            case State.unemployed:
                FindWork();
                break;
        }
    }

    private void FindWork()
    {
        GameObject[] workPlaces = GameObject.FindGameObjectsWithTag("Trabajo");
        for (int i = 0; i < workPlaces.Length; i++)
        {
            if(workPlaces[i].GetComponent<Trabajo>().GetOcupation() < workPlaces[i].GetComponent<Trabajo>().GetMaxOcupation())
            {
                _gameController._workers++;
                workPlaces[i].GetComponent<Trabajo>().SetOcupation(workPlaces[i].GetComponent<Trabajo>().GetOcupation() + 1);
                _state = State.working;
                return;
            }
        }
    }

}
