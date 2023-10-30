using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    private Slider slider;
    private Health health;
    void Awake()
    {
        slider = GetComponent<Slider>();
        
        health = GetComponentInParent<Health>();
        health.OnHealthChange += SetHealthBar;  

        SetHealthBar();   
    }

    private void SetHealthBar()
    {
        slider.maxValue = health.MaximumHealth;
        slider.value = health.CurrentHealth;    
    }

    void OnEnable()
    {
        slider.maxValue = health.MaximumHealth;
        slider.value = health.CurrentHealth;    
    }
}
