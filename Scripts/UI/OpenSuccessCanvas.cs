using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSuccessCanvas : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<WaveManager>().OnLevelSuccess += CompletedLevel;
    }

    void CompletedLevel()
    {
        OpenCanvas();
    }


    void OpenCanvas()
    {

        if(gameObject.TryGetComponent<Canvas>(out Canvas canvas))
        {   
            canvas.enabled = true;
        }
    }

    private void OnEnable() 
    {
        FindObjectOfType<WaveManager>().OnLevelSuccess -= OpenCanvas;
    }

}
