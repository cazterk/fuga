using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 15f;
    public float jumpForce = 4f;
    private bool facingRight;
    float movement;

    private Animator animator;
    private string currentState;


    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string JUMP = "jump";
    public const string DOWN = "down";

    public bool isGrounded;
    public bool CeilingIsHit;
    public Transform ceilingCheck;
    public Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Collider2D disableDuckCollider;

    //animation states
    const string PLAYER_IDLE = "player_idle";
    const string PLAYER__RUN = "player_run";
    const string PLAYER_JUMP = "player_jump";
    const string PLAYER_DUCK = "player_duck";

    private AudioSource player_footstep;

    string buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player_footstep = GetComponent<AudioSource>();
       
    }

    //changes animation states
    void changeAnimationState(string newState)
    {
        animator.Play(newState);
    }

    //Put non physics based movement in here
    void Update()
    {
        InputManager();

    }



    //Put physica based movement in here
    private void FixedUpdate()
    {
        HandleMovenment();
    }

    private void InputManager()
    {
        movement = Input.GetAxis("Horizontal");
      
        if (Input.GetKey(KeyCode.UpArrow))
        {
            buttonPressed = JUMP;

        } 
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            buttonPressed = DOWN;
        }
        else
        {
            buttonPressed = null;
        }
    }

    private void HandleMovenment()
    {

        Vector2 move = new Vector2(movement * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        if (buttonPressed == JUMP && isGrounded && CeilingIsHit == false)
        {
           
                rb.AddForce(Vector2.up * jumpForce);
                changeAnimationState(PLAYER_JUMP);
                AudioManager.PlaySound("player_jump_hop");



        }
        else if (buttonPressed == DOWN && isGrounded)
        {
           
                disableDuckCollider.enabled = false;
                changeAnimationState(PLAYER_DUCK);
           
        }

        else if (isGrounded)
        {
            if (movement != 0 && CeilingIsHit == false)
            {
                changeAnimationState(PLAYER__RUN);
                

            }
            else if (CeilingIsHit == true)
            {
                changeAnimationState(PLAYER_DUCK);
                Debug.Log("ceiling hit!!!!!!!!!");

            }
            else
            {
                changeAnimationState(PLAYER_IDLE);
            }
        } else if (!CeilingIsHit)
        {
            disableDuckCollider.enabled = true;

        }




        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        CeilingIsHit = Physics2D.OverlapCircle(ceilingCheck.position, 0.2f, groundLayer);
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);

    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;

        }
    }

    private void Footstep()
    {
        player_footstep.Play();
    }

}
