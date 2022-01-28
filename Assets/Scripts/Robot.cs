using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : Enemy
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;   
    
    
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
        if (CanSeePlayer(agroRange) && ProjectilePrefab.timeWhenAllowedNextShoot <= Time.time )
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            ProjectilePrefab.timeWhenAllowedNextShoot = Time.time + ProjectilePrefab.timeBetweenShooting;
            Debug.Log("is firing");
        }
    }
}
