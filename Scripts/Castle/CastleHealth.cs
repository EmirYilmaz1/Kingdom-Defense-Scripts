using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHealth : MonoBehaviour
{
    public event Action OnCastleDown;
    public event Action OnCastleHealthChange;

    [SerializeField] private int currentCastleHealth = 10;
    public int CurrentCastleHealth{get{return currentCastleHealth;}}
    void Start()
    {
        GetComponent<CastleColliderHandler>().OnEnemyEnter +=  DecreaseHealth; 
    }

    void DecreaseHealth()
    {
        currentCastleHealth--;
        OnCastleHealthChange?.Invoke();
        if(currentCastleHealth<=0)
        {
            OnCastleDown?.Invoke();
            Time.timeScale = 0;
        }
    }

}
