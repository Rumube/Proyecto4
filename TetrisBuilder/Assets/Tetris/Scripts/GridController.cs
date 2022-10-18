using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridController : MonoBehaviour
{
    public GameObject _selectedArea;
    public static bool _isActive;
    public GameController _gc;
    public Button _HauseButton;
    public Button _WorkButton;
    public static int Contador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _selectedArea.SetActive(_isActive);
        if (_gc._gameState == GameController.GameState.Build)
        {

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.gameObject.tag == "Ground")
            {
                _selectedArea.transform.position = new Vector3(Mathf.Round(hit.point.x), Mathf.Round(hit.point.y), Mathf.Round(hit.point.z));
            }
        }

        if (_isActive == true)
        {
            _HauseButton.interactable = false;
            _WorkButton.interactable = false;
        }
        if (_isActive == false)
        {
            _HauseButton.interactable = true;
            _WorkButton.interactable = true;
        }

    }

    public void ActiveGridController()
    {
        _isActive = !_isActive;
        Contador = Contador + 1;
        City.day = +1;
        _gc.GetComponent<GameController>().SetBuild(_isActive);
    }


}
