using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    //STATS
    public int _population;
    public int _materials;
    public int _workPlaces;
    public int _workers;

    //UI
    public TextMeshProUGUI _populationText;
    public TextMeshProUGUI _materialsText;
    public TextMeshProUGUI _workText;
    public TextMeshProUGUI _workersText;

    //BUILDING DATA
    public GameObject _dataPanel;
    public TextMeshProUGUI _dataNameText;
    public GameObject _ocupationPanel;
    public GameObject _citizenOcupation;
    public List<Sprite> _citizenOcupationImage;

    public float _nextMaterialUpdate = 0;

    public TetrisController _tetris;
    public enum GameState
    {
        Build,
        Zone,
        Tetris
    }

    public GameState _gameState = GameState.Zone;


    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        switch (_gameState)
        {
            case GameState.Build:
                BuildController();
                break;
            case GameState.Zone:
                InputZoneController();
                break;
            case GameState.Tetris:
                break;
            default:
                break;
        }

        if (Time.realtimeSinceStartup >= _nextMaterialUpdate)
        {
            _nextMaterialUpdate = Time.realtimeSinceStartup + 5f;
            UpdateGenerate();
        }

    }

    private void InputZoneController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.gameObject.GetComponentInParent<Build>() != null)
                {
                    _dataPanel.SetActive(true);
                    Build currentBuild = hit.collider.gameObject.GetComponentInParent<Build>();
                    _dataNameText.text = currentBuild.GetData();

                    for (var i = _ocupationPanel.transform.childCount - 1; i >= 0; i--)
                    {
                        Object.Destroy(_ocupationPanel.transform.GetChild(i).gameObject);
                    }

                    for (int i = 0; i < currentBuild.GetOcupation(); i++)
                    {
                        GameObject newCitizen = Instantiate(_citizenOcupation);
                        newCitizen.transform.SetParent(_ocupationPanel.GetComponent<RectTransform>());
                        int random = Random.Range(0, _citizenOcupationImage.Count);
                        newCitizen.GetComponent<Image>().sprite = _citizenOcupationImage[random];
                    }
                }
            }
        }
    }

    public void SetBuild(bool value)
    {
        if (value)
        {
            _gameState = GameState.Build;
        }
        else
        {
            _gameState = GameState.Zone;
            //Camera.main.GetComponent<CameraController>().SwitchCameraMode(CameraController.CameraMode.Movement);
        }
    }

    private void BuildController()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _gameState = GameState.Tetris;
            //Camera.main.GetComponent<CameraController>().SwitchCameraMode(CameraController.CameraMode.Tetris);
            _tetris.StartTetris();
        }
    }

    public void CalculatePopulation()
    {
        int currentPopulation = 0;
        GameObject[] casa = GameObject.FindGameObjectsWithTag("Casa");
        for (int i = 0; i < casa.Length; i++)
        {
            currentPopulation += casa[i].GetComponent<Casa>().GetOcupation();
        }
        _population = currentPopulation;
        UpdateUI();
    }

    public void UseMaterials(int used)
    {
        _materials -= used;
        UpdateUI();
    }

    public void AddMaterials(int added)
    {
        _materials += added;
        UpdateUI();
    }

    public void AddWorkPlaces(int added)
    {
        _workPlaces += added;
        UpdateUI();
    }

    public void UpdateUI()
    {
        _materialsText.text = _materials.ToString();
        _populationText.text = _population.ToString();
        _workText.text = _workPlaces.ToString();
        _workersText.text = _workers.ToString();
    }

    private void UpdateGenerate()
    {
        GameObject[] workplaces = GameObject.FindGameObjectsWithTag("Trabajo");
        int materialGenerated = 0;

        for (int i = 0; i < workplaces.Length; i++)
        {
            materialGenerated += workplaces[i].GetComponent<Trabajo>()._materialGenerated;
        }
        _materials += materialGenerated;
        UpdateUI();
    }


    public void CloseDataPanel()
    {
        _dataPanel.SetActive(false);
    }
}
