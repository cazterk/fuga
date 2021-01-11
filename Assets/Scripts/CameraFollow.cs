using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] [Range(0.01f, 1f)]
    private Vector3 velocity = Vector3.zero;

    [SerializeField] float leftLimt;
    [SerializeField] float rightLimt;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;


    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);


        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimt, rightLimt), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
    
    }
     
     void OnDrawGizmos()
    {
        //draw a box around our camera boundary
        Gizmos.color = Color.red;

        //top boundary line
        Gizmos.DrawLine(new Vector2(leftLimt, topLimit), new Vector2(rightLimt, topLimit));
        //right boundary line
        Gizmos.DrawLine(new Vector2(rightLimt, topLimit), new Vector2(rightLimt, bottomLimit));
        //botton boundary line
        Gizmos.DrawLine(new Vector2(rightLimt, bottomLimit), new Vector2(leftLimt, bottomLimit));
        //left boundary line
        Gizmos.DrawLine(new Vector2(leftLimt, bottomLimit), new Vector2(leftLimt, topLimit));
    }
}
