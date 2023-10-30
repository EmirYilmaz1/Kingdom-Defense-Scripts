using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnightMoveState : State
{
    [SerializeField] private Transform patrol;
    public Transform PatrolPos{get{return patrol;} set{patrol = value;}} 
    
    [SerializeField] private float attackRange;

    private NavMeshAgent navMeshAgent;
    
    private KnightManager knightManager;
    private IdleState idleState;
    private KnightAttackState attackState;

    private Animator animator;


    private void Start() 
    {
        knightManager = GetComponent<KnightManager>();
        idleState = GetComponent<IdleState>();
        attackState = GetComponent<KnightAttackState>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override State Tick()
    {
        if (knightManager.HasEnemy)
        {
            if (attackRange < Vector3.Distance(transform.position, knightManager.EnemyTransform.position))
            {
                Move(knightManager.EnemyTransform);
                return this;
            }
            else
            {
                StopMoving();
                animator.SetBool("canAttack", true);
                return attackState;
            }
        }


        if (IsComingToPatrolPos())
        {
            Move(PatrolPos);
            return this;
        }
        else
        {
            StopMoving();
            animator.SetBool("canWalk", false);
            return idleState;
        }

    }

    private bool IsComingToPatrolPos()
    {
        return 0.1 < Vector3.Distance(transform.position, PatrolPos.position);
    }

    private void Move(Transform transform)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(transform.position);
    }

    private void StopMoving()
    {
        navMeshAgent.isStopped = true;
    }
}
