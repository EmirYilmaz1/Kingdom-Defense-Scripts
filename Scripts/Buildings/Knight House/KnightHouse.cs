using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHouse : MonoBehaviour
{
    [SerializeField] private GameObject knightPrefab;
    [SerializeField] private Transform partolPos1,patrolPos2,patrolPos3;
    
    private bool ispartolPos1,ispatrolPos2,ispatrolPos3;

    private List<GameObject> knights = new List<GameObject>();
    
    void Start()
    {
        SetKnights();
    }


    private void SetKnights()
    {
       for (int i = 0; i < 3; i++)
       {
            GameObject knight = Instantiate(knightPrefab,transform.position,Quaternion.identity,transform);
            knight.GetComponent<Health>().OnDied += () => Invoke(nameof(SpawnKnights),4); 
            if(knight.TryGetComponent<KnightMoveState>(out KnightMoveState moveState))
            {
                if(!ispartolPos1)
                {
                    moveState.PatrolPos = partolPos1;
                    ispartolPos1 = true;
                }else if(!ispatrolPos2)
                {
                    moveState.PatrolPos = patrolPos2;
                    ispatrolPos2 = true;
                }
                else if(!ispatrolPos3)
                {
                    moveState.PatrolPos = patrolPos3;
                    ispatrolPos3 = true;
                }   
                
            }

            knights.Add(knight);
       }
    }

    private void SpawnKnights()
    {
        foreach(GameObject knight in knights)
        {
            if(!knight.activeInHierarchy)
            {
                knight.SetActive(true);
                knight.transform.position = transform.position;
                break;
            }
        }
    }

}
