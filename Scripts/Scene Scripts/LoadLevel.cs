using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private int sceneIndex; 
    private Button button;
    private void Start() 
    {
        button = GetComponent<Button>();
        switch(sceneIndex)
        {
            case 1:
                button.interactable =LevelManager.Instance.level1;
                break;
            case 2:
                button.interactable =LevelManager.Instance.level2;
                break;
            case 3:
                button.interactable =LevelManager.Instance.level3;
                break;
            case 4:
                button.interactable =LevelManager.Instance.level4;
                break;

        } 
    }
    public void LoadTheLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
