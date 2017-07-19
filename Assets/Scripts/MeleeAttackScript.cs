using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour {

    private bool attacking = false;
    private bool punching = false;

    private float attackTimer = 0f;
    private float attackCooldown = 0.5f;

    public Collider2D meleeTrigger;

    void Awake()
    {
        meleeTrigger.enabled = false;
    }

    void Update()
    {
        punching = Input.GetButtonDown("Fire1");

        if (punching && Time.time > attackTimer)
        {
            attackTimer = Time.time + attackCooldown;
                         
            meleeTrigger.enabled = true;             
        }
        else
        {
            meleeTrigger.enabled = false;
        }
        
    }
}
