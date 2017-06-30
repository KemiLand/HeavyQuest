/*
 * TO DO : SWITCH TO RAYCAST BASED VISION 
 *  FIX DIFFERENT LEVEL CHASING  (AN ENEMY HIGHER THAN THE PLAYER RESULTS IN THE ENEMY FLOATING TO HIS TARGET IF HE SEES HIM)
 */
using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    [SerializeField] float timeToDie = 0.8f;
    private int enemyDamage = 2;
    private float velocity = 1f;
    private int playerHit = 0; // Preventing the monster to spam hits on the player

    [SerializeField] Transform sightStart;
    [SerializeField] Transform sightEnd;
    [SerializeField] LayerMask detecting;

    //[SerializeField] Transform playerCheckStart;
    //[SerializeField] Transform playerCheckEnd;
    //[SerializeField] LayerMask detectingPlayer;

    [SerializeField] bool collidingWall;
    [SerializeField] bool collidingPlayer;

    //[SerializeField] Transform target; // The enemy will follow this
    [SerializeField] float maxDistDetection;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool grounded = false;
    private float groundRadius = 0.01f;

    private bool facingRight = true;

    private PlayerController player;

    //Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        //anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        //Might use for some ennemies
        //Move towards the player when he is in range
        /*if (Vector2.Distance(transform.position, target.position) < maxDistDetection)
        {
            if (transform.position.x > target.position.x && facingRight == true)
            {
                Flip();
                velocity *= -1;
            }
            else if (transform.position.x < target.position.x && facingRight == false)
            {
                Flip();
                velocity *= -1;
            }

            transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(target.position.x, transform.position.y, transform.position.z), 1f * Time.deltaTime);
        }*/

        GetComponent<Rigidbody2D>().velocity = new Vector3(velocity, 0.0f, 0.0f);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (grounded == false)
        {
            Flip();
            velocity *= -1;
        }

        //Checks if the monster walked into a wall
        collidingWall = Physics2D.Linecast(sightStart.position, sightEnd.position, detecting);

        //Check if the monster walked into the player character
        //collidingPlayer = Physics2D.Linecast(playerCheckStart.position, playerCheckEnd.position, detectingPlayer);

        if (collidingWall)
        {
            Flip();
            velocity *= -1;
        }

        if (collidingPlayer)
        {
            if (playerHit == 0)
            {
                playerHit = 1;
                player.Damage(enemyDamage);
            }
        }
        else
        {
            playerHit = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void OnDrawGizmos()
    {
        //Draws a line showing what makes the enemy rotate
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(sightStart.position, sightEnd.position);

        //Draws a line showing where the player gets hit
        Gizmos.color = Color.blue;
        //Gizmos.DrawLine(playerCheckStart.position, playerCheckEnd.position);
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        GetComponent<Animation>().Play("EnemyHit");
    }

    void Die()
    {
        //Ajouter son de mort ennemi
        velocity = 0.0f;
        //anim.SetBool("killed", true);
        Destroy(this.gameObject, timeToDie);
        gameObject.tag = "Dead";
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingRight = !facingRight;
    }
}