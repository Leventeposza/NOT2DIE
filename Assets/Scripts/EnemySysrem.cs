using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySysrem : MonoBehaviour
{
    public float lineofsite;
    public float speed;
    public Transform player;
    private Animator anim;
    private bool Inlineofsite;

    [SerializeField] float movespeed = 1f;

    Rigidbody2D rb;
    BoxCollider2D bc;

    private enum MovementState
    {
        running, idle
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsFacingRight())
        {
            rb.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-movespeed, 0f);
        }


        float distFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distFromPlayer < lineofsite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

            

            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            rb.velocity = new Vector2(0f, 0f);

        }
        UpdateAnimationUpdate();



    }
    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (rb.velocity.x == 0f)
        {
            
            state = MovementState.idle;
        }
        else
        {
            state = MovementState.running;
        }

        anim.SetInteger("state", (int)state);
    }


    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)) * 5, transform.localScale.y);
    }

}
