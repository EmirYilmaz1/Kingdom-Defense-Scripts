using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CastleHealthUI : MonoBehaviour
{

    private CastleHealth castleHealth;
    private TextMeshProUGUI textMeshProUGUI;
    
    void Start()
    {
        castleHealth = FindObjectOfType<CastleHealth>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        castleHealth.OnCastleHealthChange += SetText;
        SetText();
    }

    private void SetText()
    {   
        textMeshProUGUI.text = castleHealth.CurrentCastleHealth.ToString();
    }
}
