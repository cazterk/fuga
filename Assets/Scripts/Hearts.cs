using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public Health health;
    public int playerHealth;
    [SerializeField] Image[] hearts;
  

    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.gray;
            }
        }
    }
}
