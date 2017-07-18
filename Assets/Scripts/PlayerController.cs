/*
 * ATTACK SYSTEM
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] bool facingRight = true;
    [SerializeField] bool grounded = false;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float jumpForce = 350f;
    //[SerializeField]
    //AudioClip soundJump;
    //AudioSource m_Sound;
    //Animator anim;

    [SerializeField] string jumpButton = "Jump";
    [SerializeField] string horizontalCtrl = "Horizontal";
    //[SerializeField] string meleeButton = "Fire1";

    private bool playerHit = false; //Turns true if the player got hit
    private int maxHealth = 4;
    public int currentHealth; // Public because of the HudScript

    [SerializeField] Text countText;
    private int itemsCount = 0;
    
    void Start()
    {
        //anim = GetComponent<Animator>();
        //m_Sound = GetComponent<AudioSource>();

        currentHealth = maxHealth;
        SetCountText();
    }

    void Update()
    {
        if (grounded && Input.GetButtonDown(jumpButton))
        {
            //m_Sound.PlayOneShot(soundJump);
            //anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
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

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", grounded);
        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

        float move = Input.GetAxis(horizontalCtrl);
        //anim.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.y);

        GetComponent<Rigidbody2D>().velocity = new Vector3(maxSpeed * move, GetComponent<Rigidbody2D>().velocity.y);
        //anim.SetFloat("Speed", Mathf.Abs(move));

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        //GetComponent<Animation>().Play("Player_RedFlash");
    }

    void Die() //Reloads the first scene upon death
    {
        Debug.Log("Dead");
        //SceneManager.LoadScene("DeathScreen");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            itemsCount += 1;
            SetCountText();
            Destroy(collision.gameObject);
        }
    }

    void SetCountText()
    {
        countText.text = "Points: " + itemsCount.ToString();
        if (itemsCount >= 3)
        {
            Debug.Log("Yay");
        }
    }
}