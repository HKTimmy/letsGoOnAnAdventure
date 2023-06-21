using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerHimself;

    public SpriteRenderer sprite;

    //moving && jumping
    public Rigidbody2D rb;
    public Animator check;
    public float leftRight = 0f;
    public bool allowToMoveOrNot = true;
    public float move = 4f;
    public float jump = 7f;
    public BoxCollider2D collider;
    [SerializeField] private LayerMask jumpableGround;

    //works on decider for animation
    public enum whichAnimation { idle, running, jumping, falling};
    public whichAnimation animationState;

    //shooting
    public GameObject charging;
    public GameObject energyBall;
    public SpriteRenderer energyBallSprite;

    //mana and hp bar link
    public manaBar manabar;
    public healthBar hpbar;

    //wall sliding
    private bool isWallSliding;
    private float wallSlidingSpeed = 1f;
    [SerializeField] private LayerMask wallLayer;

    //wall Jumping
    public bool isWallJumping = false;
    private bool secoundWall = false;

    private float direction;
    public Vector2 wallJumpingVelocity = new Vector2(5f, 7f);


    // repsawn save load whatever
    private gameMaster gm;
    public GameObject monster;


    //sound
    public AudioSource pickUpSound;
    public AudioSource coinSound;



    //scale velocity if snowing
    public GameObject snow;
    public GameObject snow2;
    public bool inSnowTwo = false;


    void Start()
    {

        //sprite.enabled = true;
        Time.timeScale = 1;

        rb = GetComponent<Rigidbody2D>();
        check = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        energyBallSprite = energyBall.GetComponent<SpriteRenderer>();


        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();

        transform.position = gm.lastCheckPointPos;

    }

    // Update is called once per frame
    private void Update()
    {
        if (snow.active) checkOnSnow();
        if (!snow.active) normalVelocity();
        if (inSnowTwo == true) checkOnSnow();
        //else normalVelocity();

        if (onGround()) isWallJumping = false;

        leftRight = Input.GetAxisRaw("Horizontal");

         if (!isWallJumping)
         {
            rb.velocity = new Vector2(leftRight * move, rb.velocity.y);
         }

         if(onGround())
        {
            rb.velocity = new Vector2(leftRight * move, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && onGround() || Input.GetButtonDown("Jump") && onWall()) //only allow to jump is the player is on ground
        {
            rb.velocity = new Vector2(0, jump);

        }

        UpdateAnimation();
        WallSlide();
        wallJump();
    }

    public void checkOnSnow() {

  
            jump = 3.5f;
            move = 2f; 

    }

    public void normalVelocity() {

            jump = 7f;
            move = 4f;
    }

    private void UpdateAnimation()
    {


        // ruunning left right animation or standing still
        if (leftRight > 0f)
        {
            animationState = whichAnimation.running;
            sprite.flipX = false;
        }
        else if (leftRight < 0f)
        {
            animationState = whichAnimation.running;
            sprite.flipX = true;
        }

        else
        {
            animationState = whichAnimation.idle;
        }


        //jumping animation
        if (rb.velocity.y > 0.1f)
        {
            animationState = whichAnimation.jumping;
        }

        else if (rb.velocity.y < -0.1f)
        {
            animationState = whichAnimation.falling;
        }



            //spawn the shooting ani
            if (Input.GetKeyDown("x"))
            {
                if (manabar.currentMana != 0)
                {

                    if (sprite.flipX)
                    {
                        energyBallSprite.flipX = true;
                        Instantiate(charging, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        manabar.SpendMana();

                    }
                    else
                    {
                        energyBallSprite.flipX = false;
                        Instantiate(charging, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                        manabar.SpendMana();
                    }
                }
            }

            //charging animation
            if (Input.GetKey("x"))
            {
                //shooting the energyBall out
                if (Input.GetKeyUp("x"))
                {
                    animationState = whichAnimation.idle;
                }
            }
        //}
        check.SetInteger("decider", (int)animationState);
    }


    //check if player is on ground by moving collider down a little
    public bool onGround() {
        
  
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }

    
    //check if player is standing on wall
    public bool onWall()
    {

        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f, wallLayer);

    }

    //check if player is sliding on wall
    public bool IsWall() {
        if (sprite.flipX)
        {
            return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.left, .1f, wallLayer);
        }
        else
        {
            return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.right, .1f, wallLayer);
        }
    }

    //check if player is sliding on ground
    public bool IsGround()
    {
        if (sprite.flipX)
        {
            return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.left, .1f, jumpableGround);
        }
        else
        {
            return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.right, .1f, jumpableGround);
        }
    }


    // sliding on wall
    private void WallSlide() {
        if (IsWall() && !onGround() && leftRight != 0f || IsGround() && !onGround() && leftRight != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else {
            isWallSliding = false;
        }
    }



    // jump against where the player is facing
    private void wallJump()
    {
        if (Input.GetButtonDown("Jump") && isWallSliding && isWallJumping == false && leftRight < 0f && secoundWall == false)
        {

            isWallJumping = true;
            //secoundWall = true;
            rb.velocity = wallJumpingVelocity;
            sprite.flipX = false;

        }        

        if (Input.GetButtonDown("Jump") && isWallSliding && isWallJumping == false && leftRight > 0f && secoundWall == false)
        {
            isWallJumping = true;
            //secoundWall = true;
            rb.velocity = new Vector2(-wallJumpingVelocity.x, wallJumpingVelocity.y);
            sprite.flipX = true;

        }
    }


    //dying effect
    public void Gonzo()
    {

        rb.bodyType = RigidbodyType2D.Static; 
        check.SetTrigger("dead");
        //pauseMenu.SetActive(false);
    }


    private void restartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "gameBlocks") {
            isWallJumping = false;

        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            isWallJumping = false;


        }


        if (collision.gameObject.tag == "explosiveDamage") {
            hpbar.takeDeathDamage();
            Gonzo();
           

        }

        if (collision.gameObject.CompareTag("traps"))
        {
            hpbar.currentHealth = 0;
            Gonzo();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pot"))
        {

            pickUpSound.Play();
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            
            coinSound.Play();
        }

        if (collision.gameObject.CompareTag("dungeonCollider")) {
            if (snow2.active) {
                inSnowTwo = true;
            }
        }

        if (collision.gameObject.CompareTag("exitSnowTwoCollider"))
        {
            if (snow2.active)
            {
                inSnowTwo = false;
            }
        }
    }
}
