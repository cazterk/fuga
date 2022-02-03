using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy

{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;

    Collider2D coll;
    Rigidbody2D rb2d;


    void Start()
    {
        
    }


    void Update()
    {
        Move();
        DistanceToPlayer();
        Shoot();

       


    }

    void Shoot()
    {
        if (CanSeePlayer(agroRange) && ProjectilePrefab.timeWhenAllowedNextShoot <= Time.time)
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation);
            ProjectilePrefab.timeWhenAllowedNextShoot = Time.time + ProjectilePrefab.timeBetweenShooting;


           



        }
    }

}
