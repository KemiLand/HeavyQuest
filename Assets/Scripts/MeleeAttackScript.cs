using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackScript : MonoBehaviour {

    private bool attacking = false;
    private bool punching = false;

    private float attackTimer = 0.5f;
    private float attackCooldown = 1f;

    public Collider2D meleeTrigger;

    void Awake()
    {
        meleeTrigger.enabled = false;
    }

    void Update()
    {
        punching = Input.GetButtonDown("Fire1");

        if (punching == true && attacking == false)
        {
            attacking = true;            

            meleeTrigger.enabled = true;            
        }

        if (attacking)
        {            
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0f) //Can't spam the attack too much
            {
                attacking = false;
                meleeTrigger.enabled = false;
            }
        }        
    }
}
