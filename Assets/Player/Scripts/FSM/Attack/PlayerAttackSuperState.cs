using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSuperState : PlayerState
{
    public PlayerAttackSuperState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }

    protected bool _Attack;
    protected bool _ComboTrigger;

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _Attack = _Player._PlayerControls._Attack;

        if (_Attack) UseAttack();
    }

    public void UseAttack() => _Player._PlayerControls.UseAttack();

    public override void ExitState()
    {
        base.ExitState();

        _ComboTrigger = false;
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (_IsAnimationFinished) _StateMachine.ChangeState(_Player._IdleState);
    }

    public void CheckForCombo()
    {
        if (_ComboTrigger && _Attack)
        {
            Debug.Log("you would go into punch2");
            UseAttack();
            ComboTransition();
        }
    }
    public virtual void ComboTransition()
    {
        _ComboTrigger = false;
    }

    // end
}
