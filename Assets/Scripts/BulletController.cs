using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    [SerializeField] Vector2 speed;
    [SerializeField] float delay;
    [SerializeField] LayerMask whatIsEnemy;
    Rigidbody2D rb;
    Collider2D c2;
    Collider2D c1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c2 = GetComponent<Collider2D>();
        rb.velocity = speed;
        Destroy(gameObject, delay);
    }

    void Update()
    {
        rb.velocity = speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(c2, collision.collider);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
}
