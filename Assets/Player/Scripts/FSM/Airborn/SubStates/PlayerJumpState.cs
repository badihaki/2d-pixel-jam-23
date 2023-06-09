using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirbornSuperState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        _Player._MovementController.JumpCharacter(_Player._CharacterSheet._MoveForce.y);
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();

        _StateMachine.ChangeState(_Player._FallingState);
    }
}
