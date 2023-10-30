using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{

    private void Start() 
    {
        FindObjectOfType<WaveManager>().OnLevelSuccess += UnlockNextLevel;    
    }
    
    
    private void UnlockNextLevel()
    {
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                LevelManager.Instance.level2 = true;
                break;
            case 2:
                LevelManager.Instance.level3 = true;
                break;
            case 3: 
                LevelManager.Instance.level4 = true;
                break;
        }

    }

}
