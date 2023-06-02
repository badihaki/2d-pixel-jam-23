using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    public void InitializeStateMachine(PlayerState state)
    {
        CurrentState = state;
        CurrentState.EnterState();
    }
    public void ChangeState(PlayerState state)
    {
        CurrentState.ExitState();
        CurrentState = state;
        CurrentState.EnterState();
    }
}
