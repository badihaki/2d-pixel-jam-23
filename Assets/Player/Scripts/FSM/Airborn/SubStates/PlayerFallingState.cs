using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerAirbornSuperState
{
    public PlayerFallingState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Player._CheckGround._IsGrounded()) _StateMachine.ChangeState(_Player._IdleState);
    }
}
