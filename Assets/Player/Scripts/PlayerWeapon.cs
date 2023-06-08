using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Player player;
    [field: SerializeField] public Sword _Sword { get; private set; }
    [SerializeField] private Transform swordSpot;
    [field: SerializeField] public bool holdingSword { get; private set; }
    
    public void InitializeWeaponHolder(Player pl)
    {
        player = pl;
        _Sword = GameObject.Find("Sword").GetComponent<Sword>();
        swordSpot = transform.Find("SwordPoint");
        holdingSword = false;
    }

    private void Update()
    {
        player?._Animator.SetBool("holdingSword", holdingSword);
    }

    // end
}
