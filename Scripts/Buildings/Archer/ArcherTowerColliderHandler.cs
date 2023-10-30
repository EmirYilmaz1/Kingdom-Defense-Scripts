using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTowerColliderHandler : MonoBehaviour
{
    public event Action OnEnemyEnter; 
    public event Action OnEnemyExit;
    public GameObject Enemy{get; set;}
    
    public bool HaveEnemy{get; set;}
    private void OnTriggerEnter(Collider other) 
    {
        if(!HaveEnemy&other.gameObject.CompareTag("Enemy"))
        {
            Enemy = other.gameObject;
            HaveEnemy = true;
            OnEnemyEnter?.Invoke();
        }    
    }

    private void OnTriggerStay(Collider other) 
    {

        if(!HaveEnemy&other.gameObject.CompareTag("Enemy"))
        {
            Enemy = other.gameObject;
            HaveEnemy = true;
            OnEnemyEnter?.Invoke();
        }    
    }

    private void OnTriggerExit(Collider other) 
    {
        if(Enemy == other.gameObject)
        {
            LeaveEnemy();
        }
    }

    private void LeaveEnemy()
    {
        HaveEnemy = false;
        OnEnemyExit?.Invoke();
    }
}
