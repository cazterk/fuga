using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    private bool facingLeft = true;
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()      
    {
        if (facingLeft)
        {
            if(transform.position.x > leftCap)
            {
              if(transform.localScale.x !=1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }
            else
            {
                facingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
            else
            {
                facingLeft = true;
            }
        }
    }
}
