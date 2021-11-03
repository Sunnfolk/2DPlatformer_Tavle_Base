using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public Vector2 moveVector;
    [HideInInspector] public bool jump;
    [HideInInspector] public float longJump;
    [HideInInspector] public bool downDash;

    #region Input Actions
    private PlayerInputActions _input;
    private void Awake() { _input = new PlayerInputActions(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
    #endregion
    
    
    private void Update()
    {
        moveVector = _input.Player.Move.ReadValue<Vector2>();
        longJump = _input.Player.Jump.ReadValue<float>();
        jump = _input.Player.Jump.triggered;
        
        downDash = Keyboard.current.sKey.wasPressedThisFrame;
    }


}