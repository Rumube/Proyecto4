using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    private bool currentlyPlacing;
    private BuildingPreset curBuildingPreset;

    private float placementIndicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curPlacementPos;

    public GameObject placementIndicator;

    public static BuildingPlacer inst;

    void Awake()
    {
        inst = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            CancelBuildingPlacement();

        if(Time.time - lastUpdateTime > placementIndicatorUpdateRate && currentlyPlacing)
        {
            lastUpdateTime = Time.time;

            curPlacementPos = Selector.inst.GetCurTilePosition();
            placementIndicator.transform.position = curPlacementPos;
        }

        if(currentlyPlacing && Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }

        
    }

    public void BeginNewBuildingPlacement(BuildingPreset buildingPreset)
    {
        if(City.inst.money < buildingPreset.cost)
            return;

        currentlyPlacing = true;
        curBuildingPreset = buildingPreset;
        placementIndicator.SetActive(true);
    }

    public void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    void PlaceBuilding()
    {
        GameObject buildingObj = Instantiate(curBuildingPreset.prefab,new Vector3(curPlacementPos.x, curPlacementPos.y -0.5f, curPlacementPos.z), Quaternion.identity);
        City.inst.OnPlaceBuilding(curBuildingPreset);
        GridController.Contador = +1;
        CancelBuildingPlacement();
    }
}