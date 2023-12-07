using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D collide;
    

    public LayerMask jumpableground;
    private float dirX = 0f;
    private float moveSpeed = 7f;
    private float jump = 14f;

    public GameObject bullet;
    public Transform firepoint;

    private enum MovementState { idle, running, jumping, falling, shooting }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        collide = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        UpdateAnimationUpdate();

        
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // No rotation (facing right)
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetMouseButtonDown(0) && PauseMenu.GameIsPaused != true)
        {
            state = MovementState.shooting;
        }

        anim.SetInteger("state", (int)state);



    }


    private bool isGrounded()
    {
      return Physics2D.BoxCast(collide.bounds.center, collide.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }

    
    
}
