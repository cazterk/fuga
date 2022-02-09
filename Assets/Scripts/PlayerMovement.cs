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

    public bool isGrounded;
    public Transform groundCheck;
    [SerializeField]private LayerMask groundLayer;

    //animation states
    const string PLAYER_IDLE = "player_idle";
    const string PLAYER__RUN = "player_run";
    const string PLAYER_JUMP = "player_jump";
    const string PLAYER_DUCK = "player_duck";

    

    string buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
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
        else
        {
            buttonPressed = null;
        }
    }

    private void HandleMovenment()
    {

        Vector2 move = new Vector2(movement * moveSpeed, rb.velocity.y);
        rb.velocity = move;

        if (buttonPressed == JUMP && isGrounded)
        {
           
                rb.AddForce(Vector2.up * jumpForce);
                changeAnimationState(PLAYER_JUMP);
                AudioManager.PlaySound("player_jump_hop");



        }
        else if (isGrounded)
        {
            if (movement != 0)
            {
                changeAnimationState(PLAYER__RUN);
                AudioManager.PlaySound("player_footstep");

            }
            else
            {
                changeAnimationState(PLAYER_IDLE);
            }
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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



}
