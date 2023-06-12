using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Player player;
    [field: SerializeField] public Sword _Sword { get; private set; }
    [SerializeField] private Transform swordSpot;
    [field: SerializeField] public bool _HoldingSword { get; private set; }
    [field: SerializeField] public Transform _SwordPoint { get; private set; }
    
    public void InitializeWeaponHolder(Player pl)
    {
        player = pl;
        _Sword = GameObject.Find("Sword").GetComponent<Sword>();
        swordSpot = transform.Find("SwordPoint");
        _HoldingSword = false;
        _SwordPoint = transform.Find("SwordPoint");
    }

    private void Update()
    {
        player?._Animator.SetBool("holdingSword", _HoldingSword);
    }

    public void EquipSword()
    {
        _HoldingSword = true;
        _Sword.ChangeSwordState(Sword.SwordState.heldByPlayer);
        _Sword.TurnOnOffBody();
    }

    // end
}
