using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0f;
    public bool isAI;
    private Vector3 startPosition;
    public GameObject ball;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }
    private void Update()
    {
        if (isAI) AIMovement();

        else
        {
            PlayerMovement();
        }   
    }
    public void PlayerMovement()
    {
        movement = new Vector2 (0,Input.GetAxisRaw("Vertical"));
        rb.velocity =  movement * speed;
    }
    public void AIMovement()
    {
        if(Random.value < 0.1)
        {
            movement = Vector2.zero;
        }

        else
        {
            if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                movement = new Vector2(0, 1);
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                movement = new Vector2(0, -1);
            }
            else
            {
                movement = new Vector2(0, 0);
            }
        }
        rb.velocity = movement * speed;
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}