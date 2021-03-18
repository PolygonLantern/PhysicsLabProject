using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Movement : MonoBehaviour
{
    private PlayerControls _controls;
    private Vector2 _movementP1;
    public float speed = 1f;
    
    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Player1.Move.performed += ctx => _movementP1 = ctx.ReadValue<Vector2>();
        _controls.Player1.Move.canceled += ctx => _movementP1 = Vector2.zero;

    }

    private void OnEnable()
    {
        _controls.Player1.Enable();
    }

    private void OnDisable()
    {
        _controls.Player1.Disable();
        
    }

    private void FixedUpdate()
    {
        Move(_movementP1);
    }

    void Move(Vector2 playerMovementVector)
    {
        Vector3 movement = new Vector3(playerMovementVector.x, 0f, playerMovementVector.y) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

    }
}