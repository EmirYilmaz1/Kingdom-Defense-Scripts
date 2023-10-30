using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class KnightManager : MonoBehaviour
{
   public bool HasEnemy{get; set;}
   
   private bool ownedEnemy;
   public Transform EnemyTransform{get; set;}

   private GameObject SubscribedObject;

   private void OnTriggerEnter(Collider other) 
   {
        if(!ownedEnemy&&other.gameObject.CompareTag("Enemy"))
        {
          EnemyTransform = other.gameObject.transform;
          

          if (SubscribedObject != null)
          {
            SubscribedObject.GetComponent<Health>().OnDied -= EnemyCancel;
          }

 
          SubscribedObject = other.gameObject;
          other.gameObject.GetComponent<Health>().OnDied += EnemyCancel;
         
          if(other.gameObject.TryGetComponent<EnemyManager>(out EnemyManager enemyManager))
          {
               if(!enemyManager.HaveTarget&!ownedEnemy)
               {        
                    enemyManager.SetTarget(gameObject);
                    ownedEnemy = true;
               }
               HasEnemy = true;
          }
        }
    }

    private void OnTriggerStay(Collider other) 
    {
          if(!ownedEnemy&&other.gameObject.CompareTag("Enemy"))
        {

          EnemyTransform = other.gameObject.transform;
          
          if (SubscribedObject != null)
          {
            SubscribedObject.GetComponent<Health>().OnDied -= EnemyCancel;
          }

 
          SubscribedObject = other.gameObject;
          other.gameObject.GetComponent<Health>().OnDied += EnemyCancel;


          
          if(other.gameObject.TryGetComponent<EnemyManager>(out EnemyManager enemyManager))
          {
               if(!enemyManager.HaveTarget&!ownedEnemy)
               {    
 
                    ownedEnemy = true;
                    enemyManager.SetTarget(gameObject);
               }
               HasEnemy = true;
          }
        }

    }

   private void OnTriggerExit(Collider other) 
   {
        if(HasEnemy && other.gameObject == EnemyTransform.gameObject)
        {
          EnemyCancel();
        }    
   }

   public void EnemyCancel()
   {
     
     SubscribedObject = null;
    
    if(EnemyTransform == null) return;

    
    EnemyTransform.GetComponent<Health>().OnDied -= EnemyCancel;
     
     ownedEnemy = false;
     HasEnemy = false;
     EnemyTransform = null;
   }

   private void OnDisable() 
   {
     EnemyCancel();
   }
}