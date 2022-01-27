using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    private bool facingLeft = true;
    public float moveSpeed = 3f;

    [SerializeField] Transform player;
    [SerializeField] Transform castPoint;
    public float agroRange;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
              if(transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
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
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
            else
            {
                facingLeft = true;
            }
        }
    }

   public bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (facingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.right* castDist;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));
         
         if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }

            Debug.DrawLine(castPoint.position, hit.point, Color.yellow);

        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);

        }
        return val;
    }

    public void DistanceToPlayer()
    {
        float distToplayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("distToplayer :" + distToplayer);


      
    }
}
