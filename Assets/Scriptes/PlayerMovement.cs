using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 3f;
    public float jumpForce = 4f;
    private Animator animator;
    private string currentState;

    public const string RIGHT = "right";
    public const string LEFT = "left";
    public const string JUMP = "jump";

    //animation states
    const string PLAYER_IDLE = "player_idle";
    const string PLAYER__RUN = "player_run";
    const string PLAYER_JUMP = "player_jump";
    const string PLAYER_DUCK = "player_duck";

    [SerializeField]
    private LayerMask groundLayer;

    string buttonPressed;


    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;


        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = LEFT;


        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            buttonPressed = JUMP;


        }
        else
        {
            buttonPressed = null;
        }

    }

    //Put physica based movement in here
    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            rb.AddForce(new Vector2(moveSpeed, 0));
            changeAnimationState(PLAYER__RUN);
            Debug.Log("right");
        }
        else if (buttonPressed == LEFT)
        {
            rb.AddForce(new Vector2(-moveSpeed, 0));
            Debug.Log("left");
            changeAnimationState(PLAYER__RUN);
        }
        else if (buttonPressed == JUMP)
        {
            rb.AddForce(Vector2.up * jumpForce);
            Debug.Log("jump");
            changeAnimationState(PLAYER_JUMP);
        }
        else
        {
            changeAnimationState(PLAYER_IDLE);
        }
    }

    public LayerMask GroundLayer
    {
        get
        {
            return groundLayer;
        }
    }

    /**public bool Isground()
    {
        
    }**/
}
