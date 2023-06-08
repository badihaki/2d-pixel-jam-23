using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class PlayerState
{
    protected Player _Player;
    protected PlayerStateMachine _StateMachine;
    protected string _StateAnimationName;
    protected float _StateEnterTime;
    protected bool _IsExitingState;
    protected bool _IsAnimationFinished;

    protected bool _HoldingSword;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string stateAnimationName)
    {
        _Player = player;
        _StateMachine = stateMachine;
        _StateAnimationName = stateAnimationName;
    }

    public virtual void EnterState()
    {
        _StateEnterTime = Time.time;
        _IsExitingState = false;
        _IsAnimationFinished = false;

        _Player._Animator.SetBool(_StateAnimationName, true);
        Debug.Log("Entering state " + _StateAnimationName + " at " + _StateEnterTime);
    }
    public virtual void ExitState()
    {
        _IsExitingState = true;
        _Player._Animator.SetBool(_StateAnimationName, false);
    }

    public virtual void AnimationTrigger()
    {
        //
    }
    public virtual void CheckTransitions()
    {
        //
    }

    public virtual void LogicUpdate()
    {
        CheckTransitions();
        _HoldingSword = _Player._WeaponController.holdingSword;
    }

    public virtual void PhysicsUpdate()
    {
        //
    }

    public virtual void AnimationFinishedTrigger() => _IsAnimationFinished = true;


    // end
}
