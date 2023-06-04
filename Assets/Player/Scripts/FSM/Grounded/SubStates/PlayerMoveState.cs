using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedSuperState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Move.x == 0) _StateMachine.ChangeState(_Player._IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _Player._MovementController.MoveCharacterHorizontally(_Move.x, _Player._CharacterSheet._MoveForce.x);
    }
}
