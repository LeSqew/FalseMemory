using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private Rigidbody2D rb;
    public bool Moving { get => Mathf.Abs(rb.velocity.x) > 0; }
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving)
        {
            animator.SetBool("Moving", true);
        }
        else { animator.SetBool("Moving", false); }
        Flip();
    }
    void Flip()
    {
        if (rb.velocity.x < 0) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
    }
}
