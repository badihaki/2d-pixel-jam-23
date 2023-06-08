using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [field: SerializeField] public Vector2 _Move { get; private set; }
    public void OnMove(InputValue value) => ProcessMove(value.Get<Vector2>());
    [field:SerializeField] public bool _Jump { get; private set; }
    public void OnJump(InputValue value) => ProcessJump(value.isPressed);
    public void UseJump() => _Jump = false;
    [field: SerializeField] public bool _Attack { get; private set; }
    public void OnAttack(InputValue value) => ProcessAttack(value.isPressed);
    public void UseAttack() => _Attack = false;
    [field: SerializeField] public bool _Weapon { get; private set; }
    public void OnWeapon(InputValue value) => ProcessWeapon(value.isPressed);
    public void UseWeapon() => _Weapon = false;
    [field: SerializeField] public bool _Grab { get; private set; }
    public void OnGrab(InputValue value) => ProcessGrab(value.isPressed);
    public void UseGrab() => _Grab = false;

    // Process Inputs Below
    private void ProcessMove(Vector2 input)
    {
        Vector2 modifiedInput = input;
        if (modifiedInput.x > 0) modifiedInput.x = 1;
        else if (modifiedInput.x < 0) modifiedInput.x = -1;
        if (modifiedInput.y > 0) modifiedInput.y = 1;
        else if (modifiedInput.y < 0) modifiedInput.y = -1;
        _Move = modifiedInput;
    }
    private void ProcessJump(bool input) => _Jump = input;
    private void ProcessAttack(bool input) => _Attack = input;
    private void ProcessWeapon(bool input) => _Weapon = input;
    private void ProcessGrab(bool input) => _Grab = input;

    // end
}