using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttackState : State
{
    private KnightManager knightManager;

    private KnightMoveState moveState;

    private bool isAttacking;
    private Animator animator;

    private int damage = 10;
    public int Damage{get{return damage;} set{damage = value;}}


    private void Awake() 
    {
        moveState = GetComponent<KnightMoveState>();
        knightManager = GetComponent<KnightManager>();   
        animator = GetComponent<Animator>(); 
    }

    public override State Tick()
    {
        if(knightManager.HasEnemy)
        {
            if(!isAttacking)
            {
                StartCoroutine(AttackSequence());
            }
            return this;
        }
        StopAllCoroutines();
        isAttacking = false;
        animator.SetBool("canAttack", false);
        return moveState;
    }

    private IEnumerator AttackSequence()
    {
        isAttacking = true;
        transform.LookAt(knightManager.EnemyTransform);
        yield return new WaitForSeconds(1f);


        if(knightManager.EnemyTransform.TryGetComponent<Health>(out Health health))
        {
            health.CurrentHealth-=Damage;
        }
  
        isAttacking = false;
    }

    private void OnEnable() {
        isAttacking = false;
    }
}
