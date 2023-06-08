using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSuperState : PlayerState
{
    public PlayerAttackSuperState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    protected bool _Attack;

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _Attack = _Player._PlayerControls._Attack;
    }

    public override void ExitState()
    {
        base.ExitState();

        _Attack = false;
    }
}
