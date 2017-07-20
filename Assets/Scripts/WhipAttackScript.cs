using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttackScript : MonoBehaviour {

    private bool whip = false;
    private bool punching = false;

    private float attackTimer = 0f;
    private float attackCooldown = 0.5f;

    public Collider2D whipTrigger;
    public Collider2D meleeTrigger;
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
        punching = Input.GetButtonDown("Fire1");

        if (whip && Time.time > attackTimer)
        {
            Debug.Log("Whip");
            attackTimer = Time.time + attackCooldown;

            rend.enabled = true;
            whipTrigger.enabled = true;
        }
        else
        {
            rend.enabled = false;
            whipTrigger.enabled = false;
        }
        
        if (punching && Time.time > attackTimer)
        {
            Debug.Log("Machette");
            attackTimer = Time.time + attackCooldown;

            meleeTrigger.enabled = true;
            
        }
        else
        {
            meleeTrigger.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyClone")
        {
            enemy = collision.gameObject.GetComponent<EnemyScript>();
            if (enemy.stunned == true)
            {
                enemy.Die();
            }
            else
            {
                enemy.GetStunned();
            }            
        }
    }
}
