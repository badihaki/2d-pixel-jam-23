using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
        CalculateDistance();
    }

    public void FlyingState()
    {
        print("sword flying dangerously through the air");
        CalculateDistance();
    }

    public void HeldState()
    {
        print("sword is in player's hands");
        sword.transform.position = player._WeaponController._SwordPoint.position;
        sword._DistanceToPlayer = 0.00f;
    }

    private void CalculateDistance()
    {
        sword._DistanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

    }

}
