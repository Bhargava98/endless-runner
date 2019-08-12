using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class PlayerControl : MonoBehaviour
{
    public float speed; 
    Rigidbody2D rb;
    public Transform groundCheck;
    bool isGround;
    public float checkRadius;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public LayerMask whatIsGround;

    //public bool collwithBox = false;
    public bool shouldLerp;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public bool isCollidingwitheWall = false;

    Animator animate;


    void Start()
    {
        Time.timeScale = 1;
        animate = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
       
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            jumpfunc();   
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                jumpfunc();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

    }
    private void FixedUpdate()
    {
                      //PLAYER MOVEMENT
        //float inputX = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        Debug.Log(speed);
        animate.SetBool("isRunning", true);
        
    }

    void jumpfunc()
    {
        animate.SetTrigger("isJumpingAnim");
        rb.velocity = Vector2.up * jumpForce;
     
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("MetalBox"))
        {
            //collwithBox = true;
            //shouldLerp = true;
            isCollidingwitheWall = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ThornWheel"))
        {
            gameObject.SetActive(false);
            Time.timeScale = 0;
            
            //speed = 0;
        }
    }

    
}
