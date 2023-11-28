using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private float JumpForce = 14f;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private AudioSource JumpEffect;
    public enum MovementState { idle, running , jumping ,falling} 

    private Animator animator;
    private float dirX = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
         dirX = SimpleInput.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * MoveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        UpdateAnimations();
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            JumpEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }

    private void UpdateAnimations()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

       else if(dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y >.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
       
    }

}
