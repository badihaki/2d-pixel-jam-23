using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStateLogic : MonoBehaviour
{
    private Sword sword;
    private Player player;

    public void InitializeState(Player _player, Sword _sword)
    {
        player = _player;
        sword = _sword;
    }
    public void IdleState()
    {
        print("sword is idle");
    }

    public void FlyingState()
    {
        print("sword flying dangerously through the air");
    }

    public void HeldState()
    {
        print("sword is in player's hands");
    }
}
