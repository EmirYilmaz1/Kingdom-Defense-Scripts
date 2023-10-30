using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsInfo : MonoBehaviour
{
    [SerializeField] private Canvas infoCanvas;
    public void OpenBuildingInfoCanvas() 
    {
        infoCanvas.enabled = true; 
    }
}
