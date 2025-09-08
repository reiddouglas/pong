using System;
using UnityEngine;
using UnityEngine.Windows;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Vector2 speed = new Vector2(5.0f,5.0f);
    public Vector2 dir;

    [SerializeField] private AudioClip bounceSoundClip;
    [SerializeField] private AudioClip scoreSoundClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {

        Vector3 screenTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 screenBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 pos = rb.position + speed * dir * Time.fixedDeltaTime;

        // check if a point is scored
        if(pos.x < screenBottom.x + sr.bounds.extents.x)
        {
            ScoreManager.Instance.AddPoint(1);
            SoundFXManager.Instance.PlaySoundFXClip(scoreSoundClip, transform, 1f);
        } else if (pos.x > screenTop.x - sr.bounds.extents.x)
        {
            SoundFXManager.Instance.PlaySoundFXClip(scoreSoundClip, transform, 1f);
            ScoreManager.Instance.AddPoint(0);
        }

        // check screen bounce
        if (pos.y < screenBottom.y + sr.bounds.extents.y)
        {
            dir = dir - 2 * Vector2.Dot(dir, Vector2.up) * Vector2.up;
            dir.Normalize();
            SoundFXManager.Instance.PlaySoundFXClip(bounceSoundClip, transform, 1f);
        }
        else if (pos.y > screenTop.y - sr.bounds.extents.y)
        {
            dir = dir - 2 * Vector2.Dot(dir, Vector2.down) * Vector2.down;
            dir.Normalize();
            SoundFXManager.Instance.PlaySoundFXClip(bounceSoundClip, transform, 1f);
        }

        pos.y = Mathf.Clamp(pos.y, screenBottom.y + sr.bounds.extents.y, screenTop.y - sr.bounds.extents.y);
        rb.MovePosition(pos);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            // find diference in position and have it move that way!
            dir = (rb.position - collision.rigidbody.position);
            dir.Normalize();
            SoundFXManager.Instance.PlaySoundFXClip(bounceSoundClip, transform, 1f);
        }
    }
}
