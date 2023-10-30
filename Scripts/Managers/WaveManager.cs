using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public event Action OnLevelSuccess;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<int> enemyCount;
    [SerializeField] private List<int> spawnTime;
    [SerializeField] Image knob;


    private int currentWave;
    private float waveTime;
    private bool canSpawn;
    private bool wave1,wave2,wave3;
    private List<GameObject> enemys = new List<GameObject>();
    private Transform finishLine;
    private int lastWaveEnemyCount;

    void Awake()
    {
        finishLine = GameObject.FindGameObjectWithTag("Finish").transform;
        SetEnemy(); 
        SpawnEnemy();
    }

    private void Update() 
    {
        knob.fillAmount = waveTime/spawnTime[currentWave];
        waveTime += Time.deltaTime;

        if(waveTime>spawnTime[0]&!wave1)
        {
            wave1 = true;
            canSpawn = true;
            waveTime = 0;
        }
        else if(waveTime>spawnTime[1]&!wave2)
        {
            wave2 = true;
            canSpawn = true;
            waveTime = 0;
        }
        else if(waveTime>spawnTime[2]&!wave3)
        {
            wave3 = true;
            canSpawn = true;
        }


        if(canSpawn)
        {
            StartCoroutine(SpawnEnemy());
        }
    }


    private IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        for(int i = 0; i<enemyCount[currentWave];++i)
        {
            foreach(GameObject enemy in enemys)
            {
                if(!enemy.activeInHierarchy)
                {
                    enemy.SetActive(true);
                    enemy.transform.position = transform.position;

                    if(wave3)
                    {
                        lastWaveEnemyCount++;
                        enemy.GetComponent<Health>().OnDied += () => CheckFinished(enemy);
                    }

                    yield return new WaitForSeconds(1.0f);
                    break;
                }
            }
        }

        if(currentWave<2)
        currentWave++;
    }

    private void SetEnemy()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab,transform.position,Quaternion.identity);
            enemys.Add(enemy);
            enemy.GetComponent<EnemyMoveState>().FinishLine = finishLine;
            enemy.SetActive(false); 
        }
    }

    private void CheckFinished(GameObject enemy)
    {
        enemy.GetComponent<Health>().OnDied -= () => CheckFinished(enemy);
        lastWaveEnemyCount-=1;


        if(lastWaveEnemyCount==0)
        {
            Time.timeScale = 0;
            OnLevelSuccess?.Invoke();
        }
    }

}
