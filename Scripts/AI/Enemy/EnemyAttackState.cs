using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    [SerializeField] private int enemyDamage;

    private EnemyManager enemyManager;
    private EnemyMoveState enemyMoveState;

    private bool isAttacking;
    private Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
        enemyManager = GetComponent<EnemyManager>();
        enemyMoveState = GetComponent<EnemyMoveState>();
    }
    public override State Tick()
    {
        if(!enemyManager.HaveTarget)
        {
            isAttacking = false;
            animator.SetBool("canAttack", false);
            StopAllCoroutines();
            return enemyMoveState;
        }

        if(!isAttacking)
        {
            StartCoroutine(AttackSequence());
        }

        return this;
    }

    private IEnumerator AttackSequence()
    {
        isAttacking = true;
        transform.LookAt(enemyManager.Knight.transform);
        yield return new WaitForSeconds(.5f);
        if(enemyManager.Knight.TryGetComponent<Health>(out Health health))
        {
            health.CurrentHealth-= enemyDamage;
        }
        isAttacking = false;
    }
}
