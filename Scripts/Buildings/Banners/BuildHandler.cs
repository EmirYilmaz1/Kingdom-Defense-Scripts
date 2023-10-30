using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildHandler : MonoBehaviour
{
    
    [SerializeField] private GameObject[] build = new GameObject[4];
    [SerializeField] private GameObject banner;
    [SerializeField] private ParticleSystem buildVFX;

    private GameObject building;
    private OpenBuildCanvas openBuildCanvas;

    private void Awake() 
    {
        openBuildCanvas = GetComponentInParent<OpenBuildCanvas>();  
    }

    public void BuidKnightHouse()
    {
        if(MoneyManager.Instance.CanAfford(75))
        {
            BuildTheBuilding(0);
            CloseCanvas();
        }
    }

    public void BuildArcherTower()
    {
        if(MoneyManager.Instance.CanAfford(50))
        {
            BuildTheBuilding(1);
            CloseCanvas();
        }
    }

    private void BuildTheBuilding(int index)
    {
        building = Instantiate(build[index], transform.position, Quaternion.identity,transform);
        building.transform.rotation = transform.rotation;
        SetBannerOf();
        building.GetComponent<SellBuilding>().OnBuildSold +=SetBannerOn;
        buildVFX.Play();
    }

    private void CloseCanvas()
    {
        openBuildCanvas.BuildCanvas.enabled = false;
    }

    private void SetBannerOf()
    {
        banner.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
    }

    private void SetBannerOn()
    {
         banner.SetActive(true);
        building.GetComponent<SellBuilding>().OnBuildSold -= SetBannerOn;
        GetComponent<BoxCollider>().enabled = true;
        building = null;
    }
}
