using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    
    private GameObject enemy;
    private bool isAttacking;
    private  ArcherTowerColliderHandler archerTowerColliderHandler;
    private ArcherTowerLevelManager archerTowerLevelManager;
    private Health health;
    private Animator animator;

    private int bowDamage = 5;

    [SerializeField] private GameObject bow;
    [SerializeField] private GameObject archer;

    private void Awake() 
    {
        archerTowerLevelManager = gameObject.GetComponent<ArcherTowerLevelManager>();
        archerTowerLevelManager.OnLevelChanged += SetBowDamage;
        archerTowerColliderHandler = GetComponent<ArcherTowerColliderHandler>();
        animator = archer.GetComponent<Animator>();
        archerTowerColliderHandler.OnEnemyEnter += SetTarget;
        archerTowerColliderHandler.OnEnemyExit += NotTarget;
    }

    private void Update()
    {
        if(enemy!=null)
        {
            if(!isAttacking)
            {
                archer.transform.LookAt(enemy.transform);
                StartCoroutine(ThrowArrow());
            }
        }
    }

    private IEnumerator ThrowArrow()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        InstantiateArrow();
        isAttacking = false;
    }

    private void SetTarget()
    {
        enemy = archerTowerColliderHandler.Enemy;
        health = enemy.GetComponent<Health>();
        health.OnDied += NotTarget;
        animator.SetBool("isShooting",true);
    }
    
    private void NotTarget()
    {
        health.OnDied -= NotTarget;
        enemy = null;
        StopAllCoroutines();
        isAttacking = false;
        health = null;
        animator.SetBool("isShooting",false);
        archerTowerColliderHandler.HaveEnemy = false;
    }

    private void InstantiateArrow()
    {
        GameObject bow = Instantiate(this.bow, archer.transform.position, Quaternion.identity);
        bow.GetComponent<ArrowFollow>().EnemyToFollow = enemy;
        bow.GetComponent<ArrowColliderHandler>().Damage = bowDamage;
    }

    private void SetBowDamage()
    {
        bowDamage = archerTowerLevelManager.CurrentArcherHouseTypes.bowDamage;
    }

}
