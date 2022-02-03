using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour 

{
    public Enemy EnemyPrefab;
    public float speed = 3.5f;
    public float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 1f;
    public Rigidbody2D rb;

    PlayerMovement target;
    Vector2 moveDirection;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}

