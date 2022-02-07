using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Collectable"))
        {
            string itemType = collision.gameObject.GetComponent<Collectables>().itemType;
            Debug.Log("we have collected a: "+ itemType);

            inventory.Add(itemType);
            Debug.Log("inventory length is " + inventory.Count);
            Destroy(collision.gameObject);
        }
    }
}
