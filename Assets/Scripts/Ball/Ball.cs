using System;
using UnityEngine;
using UnityEngine.Windows;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 speed = new Vector2(5.0f,3.0f);
    private Vector2 dir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        dir = new Vector2(1, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = rb.position + speed * dir * Time.fixedDeltaTime;
        rb.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // find diference in position and have it move that way!
            dir = (rb.position - collision.rigidbody.position);
            dir.Normalize();
        } else if (collision.gameObject.tag.Equals("Wall"))
        {
            // find normal and reflect ball
            ContactPoint2D contact = collision.GetContact(0);
            dir = dir - 2 * Vector2.Dot(dir,contact.normal) * contact.normal;
            dir.Normalize();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("hit!");

        }
        Debug.Log("hit!");
    }

}
