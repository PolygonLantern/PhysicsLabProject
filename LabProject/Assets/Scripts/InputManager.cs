using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    
    public bool jumped;
    public bool hold;
    public bool attacked;
    public Vector2 getMouseDelta;
    public Vector2 getPlayerMovement;
    
    private PlayerControls _controls;
    
    
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
        _controls = new PlayerControls();

        _controls.Player.Jump.performed += ctx => jumped = _controls.Player.Jump.triggered;
        _controls.Player.Jump.canceled += ctx => jumped = false;
        
        _controls.Player.Hold.performed += ctx => hold = _controls.Player.Hold.triggered;
        _controls.Player.Hold.canceled += ctx => hold = false;
        
        _controls.Player.Attack.performed += ctx => attacked = true;
        _controls.Player.Attack.canceled += ctx => attacked = false;
        
        _controls.Player.Look.performed += ctx => getMouseDelta = ctx.ReadValue<Vector2>();
        _controls.Player.Look.canceled += ctx => getMouseDelta = Vector2.zero;

        _controls.Player.Move.performed += ctx => getPlayerMovement = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => getPlayerMovement = Vector2.zero;


    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
    
}
