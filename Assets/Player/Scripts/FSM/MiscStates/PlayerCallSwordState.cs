using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCallSwordState : PlayerState
{
    public PlayerCallSwordState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }
    private bool weapon;
    public override void EnterState()
    {
        base.EnterState();

        _Player._MovementController.ZeroStopVelocity();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        weapon = _Player._PlayerControls._Weapon;

        // if player.weaponcontrols.weapon then player.weaponcontrols.sword.callsword
        _Player._WeaponController._Sword._MoveController.PullToTransform(_Player._WeaponController._SwordPoint);
    }

    public override void CheckTransitions()
    {
        base.CheckTransitions();

        if (!weapon) _StateMachine.ChangeState(_Player._IdleState);
        else
        {
            if(_Player._WeaponController._Sword._DistanceToPlayer < 1.00f)
            {
                _Player._WeaponController.EquipSword();
                _StateMachine.ChangeState(_Player._IdleState);
            }
        }
    }
}
