using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        MoneyManager.Instance.OnMoneyChange += SetText;
        SetText();
    }

    private void SetText()
    {
        textMeshProUGUI.text = MoneyManager.Instance.CurrentMoney.ToString();
    }

    
}
