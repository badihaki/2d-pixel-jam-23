using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedSuperState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }
}
