using System;
using UnityEngine;
using UnityEngine.Windows;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Vector2 speed = new Vector2(5.0f,5.0f);
    public Vector2 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        dir = new Vector2(1, 0);
    }

    private void FixedUpdate()
    {

        float screenTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y;
        float screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        Vector2 pos = rb.position + speed * dir * Time.fixedDeltaTime;

        // check if a point is scored
        if(pos.x < screenBottom)
        {
            ScoreManager.Instance.AddPoint(1);
        } else if (pos.x > screenTop)
        {
            ScoreManager.Instance.AddPoint(0);
        }

        if (pos.y < screenBottom + sr.bounds.extents.y)
        {
            dir = dir - 2 * Vector2.Dot(dir, Vector2.up) * Vector2.up;
            dir.Normalize();
        }
        else if (pos.y > screenTop - sr.bounds.extents.y)
        {
            dir = dir - 2 * Vector2.Dot(dir, Vector2.down) * Vector2.down;
            dir.Normalize();
        }

        pos.y = Mathf.Clamp(pos.y, screenBottom + sr.bounds.extents.y, screenTop - sr.bounds.extents.y);
        rb.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // find diference in position and have it move that way!
            dir = (rb.position - collision.rigidbody.position);
            dir.Normalize();
        }
    }
}
