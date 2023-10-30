using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColliderHandler : MonoBehaviour
{
    private GameObject enemy;
    public int Damage{get; set;}
    private void Start() 
    {
        enemy = GetComponent<ArrowFollow>().EnemyToFollow;
    }
   private void OnTriggerEnter(Collider other) 
   {
        if(other.gameObject == enemy)
        {
            if(enemy.TryGetComponent<Health>(out Health health))
            {
                health.CurrentHealth -= Damage;
            }
        } 
   }
}
