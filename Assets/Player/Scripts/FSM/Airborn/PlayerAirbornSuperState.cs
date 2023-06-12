using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAirbornSuperState : PlayerState
{
    public PlayerAirbornSuperState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    protected Vector2 _Move;

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        _Move = _Player._PlayerControls._Move;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _Player._MovementController._AirbornHorizontalMovement(_Move.x, _Player._CharacterSheet._MoveForce.x);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Player._CheckGround._IsGrounded() && Time.time > _StateEnterTime + 0.15f) _StateMachine.ChangeState(_Player._IdleState);
    }
}
