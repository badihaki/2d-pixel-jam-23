using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAirbornSuperState : PlayerState
{
    public PlayerAirbornSuperState(Player player, PlayerStateMachine stateMachine, string stateAnimationName) : base(player, stateMachine, stateAnimationName)
    {
    }
}
