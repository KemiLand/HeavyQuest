using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttackScript : MonoBehaviour {

    private bool attacking = false;
    private bool whip = false;

    private float attackTimer = 0f;
    private float attackCooldown = 0.5f;

    public Collider2D whipTrigger;
    private EnemyScript enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }

    void Awake()
    {
        whipTrigger.enabled = false;
    }

    void Update()
    {
        whip = Input.GetButtonDown("Fire2");

        if (whip && Time.time > attackTimer)
        {
            attackTimer = Time.time + attackCooldown;

            whipTrigger.enabled = true;
        }
        else
        {
            whipTrigger.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy.GetStunned();
        }
    }
}
