using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 0f;
    public Vector3 startPosition;
    public LifeManager player1LifeManager;
    public LifeManager player2LifeManager;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        Move();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude != speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Move();
    }

    public void Move()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier1"))
        {
            player1LifeManager.ReduceHealth(1);
            GameManager.instance.ResetPosition();
        }

        if (collision.gameObject.CompareTag("Barrier2"))
        {
            GameManager.instance.ResetPosition();
        }
    }
}