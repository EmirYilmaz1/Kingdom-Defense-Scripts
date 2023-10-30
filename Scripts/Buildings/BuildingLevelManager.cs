using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BuildingLevelManager : MonoBehaviour
{
    public event Action OnLevelChanged;
    [SerializeField] protected int baseSellMoney = 50;
    public int BaseSellMoney{get{return baseSellMoney;}}
    [SerializeField] private TextMeshProUGUI cantAffordText;
    [SerializeField] private TextMeshProUGUI maxLevelText;

    protected int houseLevel =1;
    public int HouseLevel{get{return houseLevel;}}

    public abstract void CanUpgrade();
    public abstract void UpgradeBuildings();

    [SerializeField] protected TextMeshProUGUI upgradeMoney;
    [SerializeField] protected TextMeshProUGUI sellMoney;

    private void Start()
    {
      SetUpgradeText();
      SetSellText();
    }

    private void SetUpgradeText()
    {
      upgradeMoney.text = UpgradeCost().ToString();
    }
    private void SetSellText()
    {
      sellMoney.text = (baseSellMoney*houseLevel).ToString();
    }

    protected IEnumerator ShowCantAffordMessage()
    {
      cantAffordText.enabled = true;
      yield return new WaitForSecondsRealtime(1.5f);
      cantAffordText.enabled = false;
    }

    protected IEnumerator ShowMaximumLevelMessage()
    {
      maxLevelText.enabled = true;
      yield return new WaitForSecondsRealtime(1.5f);
      maxLevelText.enabled = false;
    }

    protected int UpgradeCost()
    {
      return 200*houseLevel;
    }
    
    protected void Upgraded()
    {
        GetComponentInChildren<Canvas>().enabled = false;
        OnLevelChanged?.Invoke();
        SetUpgradeText();
        SetSellText();
    }

}
