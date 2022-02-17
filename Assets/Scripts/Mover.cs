using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 36)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            speed = 0.0f;
          
        }
    }
     
}

