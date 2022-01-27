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

        if (CanSeePlayer(agroRange))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);

        }

    }
}
