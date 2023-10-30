using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBuildCanvas : MonoBehaviour
{
    [SerializeField] private Canvas buildCanvas;
    public Canvas BuildCanvas{get{return buildCanvas;} set{buildCanvas = value;}}

    public void OpenCanvas() 
    {
        buildCanvas.enabled = true;   
    }
}
