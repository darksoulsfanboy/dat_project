using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiniteStateMachine
{
    public EnemyState CurrentState;

    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
