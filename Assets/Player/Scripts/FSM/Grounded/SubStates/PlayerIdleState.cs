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
        if (_Player._CheckGround._IsGrounded() == false)
        {
            _StateMachine.ChangeState(_Player._FallingState);
        }
    }

    // end
}
