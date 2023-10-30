using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleColliderHandler : MonoBehaviour
{
    public event Action OnEnemyEnter;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            OnEnemyEnter?.Invoke();
        }    
    }
}
