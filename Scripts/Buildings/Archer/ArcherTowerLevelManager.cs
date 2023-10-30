using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerLevelManager : BuildingLevelManager
{
    [SerializeField] private List<ArcherHouseTypes> archerHouseTypes = new List<ArcherHouseTypes>();

    private ArcherHouseTypes currentArcherHouseTypes;
    public ArcherHouseTypes CurrentArcherHouseTypes{get{return currentArcherHouseTypes;}}
    public override void CanUpgrade()
    {
        if(houseLevel<3&&MoneyManager.Instance.CanAfford(UpgradeCost()))
        {
            UpgradeBuildings();
        }
        else if(houseLevel>=3)
        {
            StartCoroutine(ShowMaximumLevelMessage());
        }
        else
        {
            StartCoroutine(ShowCantAffordMessage());
        }
    }

    public override void UpgradeBuildings()
    {
        houseLevel++;
        switch(houseLevel)
        {
            case 2:
            currentArcherHouseTypes = archerHouseTypes[0];
            break;
            case 3:
            currentArcherHouseTypes = archerHouseTypes[1];
            break;
        }
        Upgraded();
    }
}
