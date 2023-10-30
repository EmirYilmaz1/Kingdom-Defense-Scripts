using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            GetComponent<Health>().OnDied?.Invoke();
        }    
    }
}
