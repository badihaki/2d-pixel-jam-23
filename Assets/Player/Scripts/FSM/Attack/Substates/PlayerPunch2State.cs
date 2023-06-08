using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch2State : PlayerAttackSuperState
{
    public PlayerPunch2State(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
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
        
        _StateMachine.ChangeState(_Player._Punch3State);
    }
}
