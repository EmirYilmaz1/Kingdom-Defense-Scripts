using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFailedCanvas : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<CastleHealth>().OnCastleDown += OpenCanvas;   
    }

    void OpenCanvas()
    {
        GetComponent<Canvas>().enabled = true;
    }

    
}
