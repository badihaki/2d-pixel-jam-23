using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedSuperState : PlayerState
{
    public PlayerGroundedSuperState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    protected Vector2 _Move;
    protected bool _Jump;
    protected bool _Attack;
    protected bool _Grab;

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        _Move = _Player._PlayerControls._Move;
        _Jump = _Player._PlayerControls._Jump;
        _Attack = _Player._PlayerControls._Attack;
        _Grab = _Player._PlayerControls._Grab;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_Player._CheckGround._IsGrounded() == false) _StateMachine.ChangeState(_Player._FallingState);
        if (_Jump) _StateMachine.ChangeState(_Player._JumpState);
    }
}
