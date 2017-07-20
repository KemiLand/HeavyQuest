using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttackScript : MonoBehaviour {

    private bool whip = false;

    private float attackTimer = 0f;
    private float attackCooldown = 0.5f;

    public Collider2D whipTrigger;
    private EnemyScript enemy;
    SpriteRenderer rend;

    private void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    void Awake()
    {
        whipTrigger.enabled = false;
    }

    void Update()
    {
        rend.enabled = false;
        whip = Input.GetButtonDown("Fire2");

        if (whip && Time.time > attackTimer)
        {
            attackTimer = Time.time + attackCooldown;

            rend.enabled = true;
            whipTrigger.enabled = true;
        }
        else
        {
            rend.enabled = false;
            whipTrigger.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyScript>();
            enemy.GetStunned();
        }
    }
}
