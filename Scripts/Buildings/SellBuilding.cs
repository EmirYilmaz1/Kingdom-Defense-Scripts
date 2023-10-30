using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellBuilding : MonoBehaviour
{
    public event Action OnBuildSold;
    public void CalculateSellMoney()
    {
        BuildingLevelManager buildingLevelManager = GetComponent<BuildingLevelManager>();
        int money = buildingLevelManager.BaseSellMoney*buildingLevelManager.HouseLevel;
        MoneyManager.Instance.CurrentMoney += money;
        Destroy(gameObject);
        OnBuildSold?.Invoke();
    }
}
