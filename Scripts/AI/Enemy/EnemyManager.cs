using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   public bool HaveTarget{get; set;}
   public GameObject Knight{get; set;}

   private void Awake() {
    GetComponent<Health>().OnDied += CantTarget;
   }

   public void SetTarget(GameObject gameObject)
   {
     HaveTarget = true;
     Knight = gameObject;
     Knight.GetComponent<Health>().OnDied += CantTarget;
   }

   public void CantTarget()
   {
      if(Knight!=null)
      {
          Knight.GetComponent<Health>().OnDied -= CantTarget;
      }
     
     HaveTarget = false;
     Knight = null;
   }
}
