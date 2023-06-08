using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch3State : PlayerAttackSuperState
{
    public PlayerPunch3State(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }
}
