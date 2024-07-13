using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;
using static Cinemachine.AxisState;

public class PlayerMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private float horizontalInput { get => Input.GetAxis("Horizontal"); }
    private float verticalInput { get => Input.GetAxis("Vertical"); }
    public float MoveSpeed;
    public float UpSpeed;
    public float JumpForce;
    private bool OnStairs;
    private bool IsGrounded
    {
        get
        {
            float rayDistance = 0.01f;
            RaycastHit2D hit = Physics2D.Raycast(rb.position - new Vector2(0, transform.localScale.y), Vector2.down, rayDistance);
            //Debug.Log(hit.collider.name);
            if (hit.collider != null && hit.collider.isTrigger != true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stairs")
            OnStairs = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stairs")
            OnStairs = false;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (OnStairs)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(horizontalInput * MoveSpeed, verticalInput * UpSpeed);
        }
        else
        {
            rb.gravityScale = 1f;
            rb.velocity = new Vector2(horizontalInput*MoveSpeed, rb.velocity.y);
        }
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    //Прыжок через тег Ground
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }*/
    void Jump()
    {
        Vector2 Force = new Vector2(rb.velocity.x, JumpForce);
        rb.AddForce(Force, ForceMode2D.Impulse);
        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
