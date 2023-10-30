using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveState : State
{ 

    public Transform FinishLine;
    [SerializeField] private float attackRange;
    
    private NavMeshAgent navMeshAgent;
    private EnemyManager enemyManager;
    private EnemyAttackState enemyAttackState;
    private Animator animator;
    private void Awake() 
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyManager = GetComponent<EnemyManager>();
        enemyAttackState = GetComponent<EnemyAttackState>();
    }
    public override State Tick()
    {   
        if(enemyManager.HaveTarget)
        {
            if(attackRange<Vector3.Distance(transform.position ,enemyManager.Knight.transform.position))
            {
                Move(enemyManager.Knight.transform);
                return this;
            }
            else
            {
                Stop();
                animator.SetBool("canAttack", true);
                return enemyAttackState;
            }
        }

        Move(FinishLine);
        return this;    
    }
    
    private void Move(Transform transform)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(transform.position);
    }

    private void Stop()
    {
        navMeshAgent.isStopped = true;
    }
}
