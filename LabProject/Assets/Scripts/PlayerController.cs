using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject test;
    InputManager _inputManager;
    public float walkSpeed = 10.0f;
    Vector3 _moveAmount;
    Vector3 _smoothMoveVelocity;
    
    Rigidbody _rigidbody;

    float jumpForce = 200.0f;
    bool _grounded;
    public LayerMask groundedMask;
    private Transform _cameraTransform;
    
    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody> ();
        _inputManager = InputManager.Instance;
        _cameraTransform = transform.GetChild(0);
        LockMouse();
    }
	
    // Update is called once per frame
    void Update ()
    {
        // movement
        Vector2 movement = _inputManager.getPlayerMovement;
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        move.y = 0f;
        Vector3 targetMoveAmount = move * walkSpeed;
        _moveAmount = Vector3.SmoothDamp (_moveAmount, targetMoveAmount, ref _smoothMoveVelocity, .15f);

        // jump
        if (_inputManager.jumped) {
            if (_grounded) {
                _rigidbody.AddForce (transform.up * jumpForce);
            }
        }

        Ray ray = new Ray (transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.25f + .1f, groundedMask)) {
            _grounded = true;
        }
        else {
            _grounded = false;
        }
    }

    void FixedUpdate() {
        
        test.transform.rotation = Quaternion.Euler(_cameraTransform.localRotation.eulerAngles);

        _rigidbody.MovePosition (_rigidbody.position + transform.TransformDirection (_moveAmount) * Time.fixedDeltaTime);
    }
    


    void LockMouse() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
