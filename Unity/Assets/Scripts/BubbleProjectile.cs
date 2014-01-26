using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class BubbleProjectile : MonoBehaviour
{
    Rigidbody2D rb = null;
    public Vector2 velocity = Vector2.zero;
    public float duration = 5f;

    void Start()
    {
        rb = rigidbody2D;
    }

    void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    void Update()
    {
        if (duration <= 0f)
            Destroy(gameObject);

        duration -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Trigger")
        {
            Destroy(gameObject);
        }
    }
}