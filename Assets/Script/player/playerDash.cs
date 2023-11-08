using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class playerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    private TrailRenderer tr;
    private bool canDash = true;
    private bool isDashing = false;
    private float dashPower = 20f;
    private float dashTime = 0.3f;
    private float dashCooldown = 1f;
    private float speedReturn;
    private Vector2 dashDirection;
    private playerMovement player;
    private float originalGravity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        player = GetComponent<playerMovement>();
    }

    void Update()
    {
        if(isDashing)
        {
            rb.velocity = dashDirection.normalized * dashPower;
            return;
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(context.performed && canDash)
        {
            canDash = false;
            isDashing = true;
            speedReturn = player.maxSpeed;
            originalGravity = rb.gravityScale;
            rb.gravityScale = 0f;
            tr.emitting = true;
            dashDirection = new Vector2(player.horizontal, 0f);
            if(dashDirection == Vector2.zero && player.isFacingRight)
            {
                dashDirection = new Vector2(transform.localScale.x, 0f);
            }
            if(dashDirection == Vector2.zero && !player.isFacingRight)
            {
                dashDirection = new Vector2(-transform.localScale.x, 0f);
            }
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        tr.emitting = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
