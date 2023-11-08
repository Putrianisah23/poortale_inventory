using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;
    public GameObject panelinventory;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); 

           if (Input.GetButtonDown("Jump")) // && IsGrounded())
        {
            rb.velocity = new Vector2( rb.velocity.x, jumpForce);        
        }

         UpdateAnimationState(); 
         OpenInventory();
    
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("walking", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
            {
                anim.SetBool("walking", true);
                sprite.flipX = true;
            }
        else
            {
                anim.SetBool("walking", false);
                // sprite.flipX = false;
            }
        }

        private void OpenInventory()
        {
             if (Input.GetKeyDown(KeyCode.C))
        {
         panelinventory.SetActive(!panelinventory.activeSelf);
        }
        }

    //     private bool IsGrounded()
    // {
    //      return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    // }
    }