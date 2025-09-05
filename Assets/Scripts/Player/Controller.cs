using System;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Controller : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected virtual KeyCode upKey => KeyCode.None;
    protected virtual KeyCode downKey => KeyCode.None;

    protected float speed = 5.0f;
    protected float input;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        input = (Input.GetKey(upKey) ? 1 : 0) - (Input.GetKey(downKey) ? 1 : 0);
    }

    protected virtual void FixedUpdate()
    {
        if (input != 0)
        {
            float screenTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0)).y;
            float screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

            Vector2 pos = rb.position + Vector2.up * input * speed * Time.fixedDeltaTime;
            pos.y = Mathf.Clamp(pos.y, screenBottom + sr.bounds.extents.y, screenTop - sr.bounds.extents.y);
            rb.MovePosition(pos);
        }
    }
}
