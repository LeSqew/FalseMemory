using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D collider;
    public int direction = 1;
    public float speed = 3f;
    private float rayDistance = 0.03f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb.velocity = new Vector2(speed * direction, 0);
        Vector2 origin = rb.position + collider.offset + new Vector2(collider.bounds.extents.x + 1f, 0) * direction; 
        //центр объекта+офсет+расстояние до края+микроотступ, чтоб об себя не билось
        Vector2 destination = Vector2.right * direction;
        RaycastHit2D hit = Physics2D.Raycast(origin, destination, rayDistance) ;
        if (hit.collider != null) { 
            direction *= -1;
            //Debug.Log($"hit: {hit.point.x}, {hit.point.y}, {hit.collider.name}");
        }
    }
}
