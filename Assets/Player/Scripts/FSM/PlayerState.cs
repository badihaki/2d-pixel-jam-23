using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player _Player;
    protected PlayerStateMachine _StateMachine;
    protected float _StateEnterTime;
    protected bool _IsExitingState;

    public virtual void EnterState()
    {
        _StateEnterTime = Time.time;
        _IsExitingState = false;
    }
    public virtual void ExitState()
    {
        _IsExitingState = true;
    }
}
