using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    State currentState;
    private void OnEnable() 
    {
        currentState = GetComponent<EnemyMoveState>();    
    }
    void Update()
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        State nextState = currentState?.Tick();
        if(nextState!=null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
