using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoney : MonoBehaviour
{
    [SerializeField] int dropMoneyAmount;
    void Start()
    {
        GetComponent<Health>().OnDied += DropTheMoney;
    }

    private void DropTheMoney()
    {
        MoneyManager.Instance.CurrentMoney += dropMoneyAmount;
    }
}
