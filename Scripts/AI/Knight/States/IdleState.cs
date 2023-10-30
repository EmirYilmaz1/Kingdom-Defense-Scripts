using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{ 
  private KnightAttackState attackState;
  private KnightMoveState moveState;

  private Transform patrolPos;
  private KnightManager knightManager;

  private Animator animator;

  private void Start() 
  {
    knightManager = GetComponent<KnightManager>();

    attackState = GetComponent<KnightAttackState>();
    moveState = GetComponent<KnightMoveState>();
    patrolPos = moveState.PatrolPos;
    animator = GetComponent<Animator>();

  }

  public override State Tick()
  {
    if(knightManager.HasEnemy)
    {
      animator.SetBool("canWalk", true);
      return moveState;
    }
    return this;
  }
}
