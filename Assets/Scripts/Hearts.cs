using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    
    public int playerHealth;
    [SerializeField] Image[] hearts;
  

    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = hearts[i].color;
            }
            else
            {
                hearts[i].color = Color.gray;
            }
        }
    }
}
