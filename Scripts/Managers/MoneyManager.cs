using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public event Action OnMoneyChange;

    [SerializeField] private int currentMoney;
    public int CurrentMoney{get{return currentMoney;}set{currentMoney = value; OnMoneyChange?.Invoke();}}

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool CanAfford(int amount)
    {
        if(CurrentMoney-amount>=0)
        {
            CurrentMoney -= amount;
            return true;
        }

        return false;
    }
    
}
