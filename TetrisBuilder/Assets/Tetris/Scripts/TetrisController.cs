using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TetrisController : MonoBehaviour
{
    public List<GameObject> _buildsList;
    public GameController _gameController;

    public GridController _gridController;
    public GameObject _buildSelections;
    public List<GameObject> _piezasCasa;
    public List<GameObject> _piezasTrabajo;
    public GameObject _construcciones;
    public enum Buildings
    {
        Casa,
        Trabajo
    }
    public Buildings _buildings;

    public GameObject _startPosition;
    private Build _currentBuild;
    private int _maxPieces = 4;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartTetris()
    {
        Toggle toggle = GetSelectedToggle();
        _maxPieces = 4;
        if (toggle != null)
        {
            switch (toggle.name)
            {
                case "Casa":
                    _buildings = Buildings.Casa;
                    GameObject _newCasa = Instantiate(_buildsList[0], _construcciones.transform);
                    _currentBuild = _newCasa.GetComponent<Casa>();
                    break;
                case "Trabajo":
                    _buildings = Buildings.Trabajo;
                    GameObject _newTrabajo = Instantiate(_buildsList[1], _construcciones.transform);
                    _currentBuild = _newTrabajo.GetComponent<Trabajo>();

                    break;
            }
        }

        _currentBuild.gameObject.transform.position = _gridController._selectedArea.transform.position;
        _startPosition.transform.position = _gridController._selectedArea.transform.position;
        _startPosition.transform.position = new Vector3(_startPosition.transform.position.x, 8, _startPosition.transform.position.z);
        CreatePiece();
    }

    private Toggle GetSelectedToggle()
    {
        Toggle[] toggles = _buildSelections.GetComponentsInChildren<Toggle>();
        foreach (var t in toggles)
            if (t.isOn) return t;  //returns selected toggle
        return null;           // if nothing is selected return null
    }

    public void CreatePiece()
    {
        _maxPieces--;
        if (_maxPieces != 0)
        {
            _gameController.UseMaterials(5);
            int randomPiece;
            GameObject newPiece;
            switch (_buildings)
            {
                case Buildings.Casa:
                    randomPiece = Random.Range(0, _piezasCasa.Count);
                    newPiece = Instantiate(_piezasCasa[randomPiece], _currentBuild.transform);
                    newPiece.transform.position = _startPosition.transform.position;
                    newPiece.GetComponent<Piece>().SetTetrisController(this);
                    break;
                case Buildings.Trabajo:
                    randomPiece = Random.Range(0, _piezasTrabajo.Count);
                    newPiece = Instantiate(_piezasTrabajo[randomPiece], _currentBuild.transform);
                    newPiece.transform.position = _startPosition.transform.position;
                    newPiece.GetComponent<Piece>().SetTetrisController(this);
                    break;
            }
        }
        else
        {
            _gridController.ActiveGridController();
            switch (_buildings)
            {
                case Buildings.Casa:
                    _currentBuild.SetOcupation(4);
                    _gameController.CalculatePopulation();
                    _currentBuild.GetComponent<Casa>().SpawnCitizens();
                    break;
                case Buildings.Trabajo:
                    _gameController.AddWorkPlaces(20);
                    break;
            }
        }

    }

    public Build GetCurrentBuild()
    {
        return _currentBuild;
    }

}
