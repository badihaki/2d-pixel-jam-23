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

        _Move = _Player._PlayerControls._Move;

        if (_Move == Vector2.zero) _Player._MovementController.JumpCharacter(0.00f, _Player._CharacterSheet._MoveForce.y);
        else
        {
            float horizontalDir = _Player._CharacterSheet._MoveForce.x;
            _Player._MovementController.JumpCharacter(horizontalDir, _Player._CharacterSheet._MoveForce.y);
        }
        _Player._PlayerControls.UseJump();
    }

    public override void AnimationFinishedTrigger()
    {
        base.AnimationFinishedTrigger();

        _StateMachine.ChangeState(_Player._FallingState);
    }
}
