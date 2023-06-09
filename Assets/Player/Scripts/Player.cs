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
    [field: SerializeField] public Animator _Animator { get; private set; }
    [field: SerializeField] public PlayerMovement _MovementController { get; private set; }
    [field: SerializeField] public PlayerWeapon _WeaponController { get; private set; }

    // state machine
    private PlayerStateMachine stateMachine;
    public PlayerIdleState _IdleState { get; private set; }
    public PlayerMoveState _MoveState { get; private set; }
    public PlayerJumpState _JumpState { get; private set; }
    public PlayerFallingState _FallingState { get; private set; }
    public PlayerPunch1State _Punch1State { get; private set; }
    public PlayerPunch2State _Punch2State { get; private set; }
    public PlayerPunch3State _Punch3State { get; private set; }

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
        _Animator = GetComponent<Animator>();
        _MovementController = GetComponent<PlayerMovement>();
        _MovementController.InitializeController();
        _WeaponController = GetComponent<PlayerWeapon>();
        _WeaponController.InitializeWeaponHolder(this);

        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        // State machine
        stateMachine = new PlayerStateMachine();

        // States
        _IdleState = new PlayerIdleState(this, stateMachine, "idle");
        _MoveState = new PlayerMoveState(this, stateMachine, "move");
        _JumpState = new PlayerJumpState(this, stateMachine, "jump");
        _FallingState = new PlayerFallingState(this, stateMachine, "falling");
        _Punch1State = new PlayerPunch1State(this, stateMachine, "punch1");
        _Punch2State = new PlayerPunch2State(this, stateMachine, "punch2");
        _Punch3State = new PlayerPunch3State(this, stateMachine, "punch3");

        // start the state machine
        stateMachine.InitializeStateMachine(_IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine?._CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        stateMachine?._CurrentState.PhysicsUpdate();
    }

    public void AnimationTrigger() => stateMachine._CurrentState.AnimationTrigger();
    public void AnimationFinishTrigger() => stateMachine._CurrentState.AnimationFinishedTrigger();
}
