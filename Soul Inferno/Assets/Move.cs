using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //reference to the animator component
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck = null;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component of the GameObject
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // change the animator's AnimState variable if a key is pressed
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            animator.SetInteger("AnimState", 1);
            rb2d.velocity = new Vector2(1, rb2d.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            animator.SetInteger("AnimState", 1);
            rb2d.velocity = new Vector2(-1, rb2d.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetInteger("AnimState", 0);
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("space") && isGrounded || Input.GetKey("w") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 4);
        }
    }
}