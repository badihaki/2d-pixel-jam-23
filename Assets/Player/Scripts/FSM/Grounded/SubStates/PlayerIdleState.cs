using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedSuperState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Move.x != 0) _StateMachine.ChangeState(_Player._MoveState);

        if (_Attack)
        {
            if (!_HoldingSword) _StateMachine.ChangeState(_Player._Punch1State);
        }
    }

    public override void EnterState()
    {
        base.EnterState();

        _Player._MovementController.ZeroStopVelocity();
    }

    // end
}
