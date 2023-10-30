using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KnightHouseLevelManager : BuildingLevelManager
{

  [SerializeField] private KnightHouseTypes[] knightHouseTypes;

  private KnightHouseTypes currentKnightHouseTypes;
  public KnightHouseTypes CurrentKnightHouseType{get{return currentKnightHouseTypes;}}



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
    switch (houseLevel)
   {
      case 2:
      currentKnightHouseTypes =knightHouseTypes[houseLevel-2];
      GetComponent<MeshFilter>().mesh = knightHouseTypes[houseLevel-2].houseMesh;
      break;
      case 3:
      currentKnightHouseTypes =knightHouseTypes[houseLevel-2];
      GetComponent<MeshFilter>().mesh = knightHouseTypes[houseLevel-2].houseMesh;
      break;
    }

      Upgraded();
  }

}
