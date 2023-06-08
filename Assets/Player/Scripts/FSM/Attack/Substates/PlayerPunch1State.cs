using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch1State : PlayerAttackSuperState
{
    public PlayerPunch1State(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        UseAttack();
        Debug.Log("usin attack");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckForCombo();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
        _ComboTrigger = true;
    }

    public override void ComboTransition()
    {
        base.ComboTransition();
        _StateMachine.ChangeState(_Player._Punch2State);
    }

}
