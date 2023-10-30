using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action OnDied;
    public event Action OnHealthChange;

    private int maximumHealth = 100;
    public int MaximumHealth{get{return maximumHealth;} set{maximumHealth = value;}}

    [SerializeField] private int currentHealth = 100;
    [SerializeField] private bool isEnemy;


    public int CurrentHealth
    {
        get{return currentHealth;} 
        set
        { 
            currentHealth= value;
            OnHealthChange?.Invoke(); 
            if(currentHealth<=0)
            {
                OnDied?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable() 
    {   
        CurrentHealth = MaximumHealth;   
    }

    private void OnDisable()
    {
        if(!isEnemy)
        {
            OnDied?.Invoke();
        }
    }

}
