using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 8f; // максимальная скорость персонажа

    public GameObject image; // кнопочка е типа
    

    internal bool open_List=false;
    public GameObject Info_List; // UI с выбором миров

    public Animator Animator;
    private Vector2 movement;

    Rigidbody2D rb;
    private float speedMove = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //rb.velocity = new Vector2(moveX, moveY).normalized * speedMove;


        

        if (!open_List)
        {
            Animator.SetFloat("Horizontal", movement.x);
            Animator.SetFloat("Vertical", movement.y);
            Animator.SetFloat("Speed", movement.sqrMagnitude);


            // Clamp the velocity to the maximum speed
            rb.MovePosition(rb.position + movement * speedMove * Time.fixedDeltaTime);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }




        if (OnDoor && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(1);
        }

        if(OnTable && Input.GetKeyDown(KeyCode.E))
        {
            if (!open_List)
            {
                Info_List.SetActive(true);
                open_List = true;
            }
            else
            {
                Info_List.SetActive(false);
                open_List = false;
            }
        }
    }

    private bool OnDoor = false;
    private bool OnTable = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            OnDoor = true;
            image.SetActive(true);
        }

        if(collision.tag == "Table")
        {
            OnTable = true;
            image.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            OnDoor = false;
            image.SetActive(false);
        }

        if (collision.tag == "Table")
        {
            OnTable = false;
            image.SetActive(false);
        }
    }
}
