using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowFollow : MonoBehaviour
{
    public GameObject a;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.MoveTowards(transform.position,a.transform.position, Time.deltaTime*100f); 
    }
}
