using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed = 3f;

    public const string RIGHT = "right";
    public const string LEFT = "left";

    string buttonPressed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.AddForce(new Vector2(moveSpeed, 3));
            Debug.Log("right");
        }
        else if (buttonPressed == LEFT)
        {
            rb.AddForce(new Vector2(-moveSpeed, 3));
            Debug.Log("left");
        }
        else
        {

        }
    }
}
