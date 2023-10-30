using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    private Camera camera;
    public Action OnVillagerSpawned;
    
    private Ray ray;
    private RaycastHit[] raycastHits;
    private SpawnSuporter spawnSuporter;
    void Start()
    {
        camera = FindObjectOfType<Camera>();
        spawnSuporter = FindObjectOfType<SpawnSuporter>();
    }


    void Update()
    {
        if (ClickedOnUi())
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            raycastHits = Physics.RaycastAll(ray);
            foreach(RaycastHit raycastHit in raycastHits)
            {
                if(EventSystem.current.IsPointerOverGameObject()) return;

                if(spawnSuporter.CanSpawnVillager)
                {
                    spawnSuporter.SpawnVillager(raycastHit.point);
                    OnVillagerSpawned?.Invoke();
                    break;
                }
                if(raycastHit.collider.TryGetComponent<BuildingsInfo>(out BuildingsInfo knightHouseInfo))
                {
                    knightHouseInfo.OpenBuildingInfoCanvas();
                    break;
                }

                if(raycastHit.collider.TryGetComponent<OpenBuildCanvas>(out OpenBuildCanvas openBuildCanvas))
                {
                    openBuildCanvas.OpenCanvas();
                    break;
                }  
            }
        }
    }

    private bool ClickedOnUi()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("UI"))
            {
                return true;
            }
        }
        return false;
    }
}
