using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private playerGround ground;

    private bool pressingKey;
    public bool onGround;
    public bool isFacingRight;
    public Animator animator;

    // New variable to control movement
    public bool canMove = true;

    public float horizontal;
    public float maxSpeed = 7f;
    private float maxAcceleration = 50f;
    private float maxDeceleration = 50f;
    private float maxAirAcceleration = 15f;
    private float maxAirDeceleration = 30f;
    private float friction = 0.95f;

    private Vector2 velocity;
    private Vector2 desiredVelocity;
    private float maxSpeedChange;
    private float acceleration;
    private float deceleration;
    private float turnSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<playerGround>();
    }

    private void Start()
    {
        isFacingRight = true;
    }

    private void Update()
    {
        if (canMove && horizontal != 0)
        {
            CheckDirection(horizontal > 0);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (canMove)
        {
            desiredVelocity = new Vector2(horizontal, 0f) * Mathf.Max(maxSpeed - friction, 0f);
        }
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();

        velocity = rb.velocity;
        moveAcceleration();
    }

    private void moveAcceleration()
    {
        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        deceleration = onGround ? maxDeceleration : maxAirDeceleration;

        if (onGround)
        {
            maxSpeedChange = acceleration * Time.deltaTime;
        }
        else
        {
            maxSpeedChange = deceleration * Time.deltaTime;
        }

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        rb.velocity = velocity;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void CheckDirection(bool isMovingRight)
    {
        if (isMovingRight != isFacingRight)
        {
            Flip();
        }
    }

    // Method to toggle movement on and off
    public void ToggleMovement(bool enableMovement)
    {
        canMove = enableMovement;
    }

    public void MoveOn()
    {
        canMove = true;
    }
    public void MoveOff()
    {
        canMove = false;
    }
}