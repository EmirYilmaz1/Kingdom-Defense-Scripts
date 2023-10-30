 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStateMachine : MonoBehaviour
{
    State currentState;

    private void OnEnable() 
    {
        currentState = GetComponent<KnightMoveState>();
    }

    private void Update() 
    {
        HandleStateMachine();
    }

    private void HandleStateMachine()
    {
        if(currentState != null)
        {
            State nextSate = currentState?.Tick();
            if(nextSate != null)
            {
                SwitchToNextState(nextSate);
            }
        }
    }

    private void SwitchToNextState(State nextSate)
    {
        currentState = nextSate;
    }
}
