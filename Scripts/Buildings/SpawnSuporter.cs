using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class SpawnSuporter : MonoBehaviour
{

    public bool CanSpawnVillager{get; set;}

    [SerializeField] private GameObject villager;

    private Image image;
    private Button button;
    private Vector3 buttonStartScale;
    private Vector3 buttonClickedScale = new Vector3(2.28f,9.465216f,1f);

    private float currentTime;
    private  int spawnSuportertime = 20;

    private bool didActionCalled;
    private bool isButtonclicked;
    

    void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.interactable = false;
        buttonStartScale = transform.localScale;

        // FindObjectOfType<InputManager>().OnVillagerSpawned += 
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        image.fillAmount = currentTime/ spawnSuportertime;
        
        if(!didActionCalled&&currentTime >= spawnSuportertime)
        {   
            ActivateButton();
        }
    }



    public void SpawnVillager(Vector3 coordinate)
    {
        GameObject villagerSuporter = Instantiate(villager,coordinate,Quaternion.identity);
       
        Transform transform = new GameObject().transform;
        transform.position = coordinate;
        villagerSuporter.GetComponent<KnightMoveState>().PatrolPos = transform;
      
        SetTimeZero();
        DeactivateButton();
        CanSpawnVillager = false;

    }

    public void SpawnButton()
    {
        if(!isButtonclicked)
        {
            isButtonclicked = true;
            CanSpawnVillager = true;
            GetComponent<RectTransform>().transform.localScale = buttonClickedScale;
        }
        else if(isButtonclicked)
        {
            isButtonclicked = false;
            CanSpawnVillager = false;
            GetComponent<RectTransform>().transform.localScale = buttonStartScale;
        }
    }

    private void ActivateButton()
    {
        button.interactable = true;
        didActionCalled = true;
    }

    private void DeactivateButton()
    {
        isButtonclicked = false;
        button.interactable = false;
        didActionCalled = false;
        GetComponent<RectTransform>().transform.localScale = buttonStartScale;
    }

    private void SetTimeZero() => currentTime = 0;


}
