using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public List<string> inventory;
    private int keyCount = 0;
    private int diamondCount = 0;
    private int rhombusCount = 0;

    [SerializeField] private Text keyText;
    [SerializeField] private Text diamondText;
    [SerializeField] private Text rhombusText;

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
            AudioManager.PlaySound("collectable");

            inventory.Add(itemType);
            Debug.Log("inventory length is " + inventory.Count);
            Destroy(collision.gameObject);

            if(itemType == "Key")
            {
                keyCount++;
                keyText.text = keyCount.ToString();
                Debug.Log("we have collected a: " + itemType + " and count is " + keyCount);

            }

            else if (itemType == "Diamond")
            {
                diamondCount++;
                diamondText.text = diamondCount.ToString();
                Debug.Log("we have collected a: " + itemType + " and count is " + diamondCount);
            } 

            else if(itemType == "BlueRhombus")
            {
                rhombusCount++;
                rhombusText.text = rhombusCount.ToString();
                Debug.Log("we have collected a: " + itemType + " and count is " + rhombusCount);
            }

            else if (itemType == "YellowRhombus")
            {
                rhombusCount++;
                rhombusText.text = rhombusCount.ToString();

                Debug.Log("we have collected a: " + itemType + " and count is " + rhombusCount);
            }
        }

    }

    public bool KeyCollect(bool keyCollected)
    {
        keyCollected = false;

        if(keyCount > 0)
        {
            keyCollected = true;
        }

        return keyCollected;
    }
}
