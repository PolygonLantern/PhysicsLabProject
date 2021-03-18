using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls _controls;
    private Vector2 _movement;
    public float speed = 1f;
    
    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Player.Move.performed += ctx => _movement = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _movement = Vector2.zero;
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
        _controls.Player1.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
        _controls.Player1.Disable();
        
    }

    private void FixedUpdate()
    {
        Move(_movement);
    }

    void Move(Vector2 playerMovementVector)
    {
        Vector3 movement = new Vector3(playerMovementVector.x, 0f, playerMovementVector.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

    }
}
