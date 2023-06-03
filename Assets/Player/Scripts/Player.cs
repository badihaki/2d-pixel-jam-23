using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField] public CharacterStatsSO _CharacterSheet { get; private set; }
    [field: SerializeField] public Health _Health { get; private set; }
    [field: SerializeField] public CheckGround _CheckGround { get; private set; }
    [field: SerializeField] public PlayerControls _PlayerControls { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerCharacter();
    }

    private void InitializePlayerCharacter()
    {
        _Health = GetComponent<Health>();
        _Health.InitializeHealth(_CharacterSheet._Health);
        _CheckGround = GetComponent<CheckGround>();
        _PlayerControls = GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
