using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class playerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private playerGround ground;
    private Animator animator;


    private float gravityStrength;
    private float gravityScale;
    private float fallGravityMult = 2f;
    private float maxFallSpeed = 80f;

    private float jumpPower;
    private float jumpHeight = 4f;
    private float jumpTimeToApex = 0.5f;
    private bool onGround;

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    private bool isJumping;
    
    private void OnValidate()
    {
        gravityStrength = -(2 * jumpHeight) / (jumpTimeToApex * jumpTimeToApex);
        gravityScale = gravityStrength / Physics2D.gravity.y;

        jumpPower = Mathf.Abs(gravityStrength) * jumpTimeToApex;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<playerGround>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        onGround = ground.GetOnGround();

        if(onGround)
        {
            animator.SetBool("onJump", false);
            coyoteTimeCounter = coyoteTime;
        }
        else
        {  
            animator.SetBool("onJump", true);
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(rb.velocity.y < 0f)
        {
            rb.gravityScale = gravityScale * fallGravityMult;
			rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = gravityScale;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
                jumpBufferCounter -= Time.deltaTime;
        }

        if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpBufferCounter = 0f;
            StartCoroutine(JumpCooldown());
        }

        if(context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.4f);
        }
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
}