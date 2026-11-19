using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    enum PlayerState 
    { 
        Idle,
        Move, 
        Dash, 
        Charge, 
        Release
    }

    PlayerState state = PlayerState.Move;
    CharacterController controller;


    [Header("movement variables-----------------------")]

    public float playerSpeed = 5;

    [Header("Dash variables---------------------------")]

    public float dashDistance = 4;
    public float dashDuration = .15f;
    public float dashCooldown = .5f;
    private float lastDashTime = -100f;
    private float dashTimer;
    private Vector3 dashDirection;

    [Header("Bow variables----------------------------")]

    public float shotRange = 10; 
    public bool isBombLoaded = false;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) 
        {
            //case PlayerState.Idle: TickIdle(); break;
            case PlayerState.Move: TickMove(); break;
            case PlayerState.Dash: TickDash(); break;
            case PlayerState.Charge: TickCharge(); break;
            case PlayerState.Release: TickRelease(); break;
        }
    }

    void SetState(PlayerState newState)
    {
        if (state == newState) return;

        ExitState(state);

        state = newState;

        EnterState(newState);
    }

    void EnterState(PlayerState newState)
    {
        switch (newState)
        {
            //case PlayerState.Idle: break;
            case PlayerState.Move: break;
            case PlayerState.Dash: 
                dashDirection = transform.forward;
                dashTimer = 0;  
                break;
            case PlayerState.Charge: break;
            case PlayerState.Release: break;
        }
    }

    void ExitState(PlayerState oldState)
    {
        switch (oldState)
        {
            //case PlayerState.Idle: break;
            case PlayerState.Move: break;
            case PlayerState.Dash: 
                lastDashTime = Time.time;
                break;
            case PlayerState.Charge: break;
            case PlayerState.Release: break;
        }
    }


    /*
    void TickIdle()
    {

    }
    */

    void TickMove()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current.wKey.isPressed) input.y += 1;
        if (Keyboard.current.sKey.isPressed) input.y -= 1;
        if (Keyboard.current.dKey.isPressed) input.x += 1;
        if (Keyboard.current.aKey.isPressed) input.x -= 1;

        Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
        controller.Move(direction * playerSpeed * Time.deltaTime);

        if (direction != Vector3.zero) transform.forward = direction;

        if(Keyboard.current.spaceKey.wasPressedThisFrame && Time.time >= lastDashTime + dashCooldown) 
        { 
            SetState(PlayerState.Dash); 
        }
    }

    void TickDash()
    {
        float dashSpeed = dashDistance / dashDuration; 
        controller.Move(dashDirection * dashSpeed * Time.deltaTime);

        dashTimer += Time.deltaTime;
        if (dashTimer > dashDuration) 
        { 
            SetState(PlayerState.Move); 
        }
    }

    void TickCharge()
    {

    }

    void TickRelease()
    {

    }
}
