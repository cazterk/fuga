using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    // Start is called before the first frame update
    void Start()
    {
        ProjectilePrefab.timeWhenAllowedNextShoot = 0f;
    }

    // Update is called once per frame
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
            AudioManager.PlaySound("shoot");
        }
    }
}
