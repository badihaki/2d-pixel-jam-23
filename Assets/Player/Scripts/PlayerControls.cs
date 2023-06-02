using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [field: SerializeField] public Vector2 Move { get; private set; }
    public void OnMove(InputValue value) => ProcessMove(value.Get<Vector2>());
    [field:SerializeField] public bool Jump { get; private set; }
    public void OnJump(InputValue value) => ProcessJump(value.isPressed);
    [field: SerializeField] public bool Attack { get; private set; }
    public void OnAttack(InputValue value) => ProcessAttack(value.isPressed);
    [field: SerializeField] public bool Weapon { get; private set; }
    public void OnWeapon(InputValue value) => ProcessWeapon(value.isPressed);
    [field: SerializeField] public bool Grab { get; private set; }
    public void OnGrab(InputValue value) => ProcessGrab(value.isPressed);
    
    // Process Inputs Below
    private void ProcessMove(Vector2 input)
    {
        Move = input;
    }
    private void ProcessJump(bool input)
    {
        Jump = input;
    }
    private void ProcessAttack(bool input)
    {
        Attack = input;
    }
    private void ProcessWeapon(bool input)
    {
        Weapon = input;
    }
    private void ProcessGrab(bool input)
    {
        Grab = input;
    }

    // end
}