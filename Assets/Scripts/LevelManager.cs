using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D finishLevel)
    {
    
        var keyCollected = finishLevel.gameObject.GetComponent<Player>().KeyCollect(true);

        if ( keyCollected && finishLevel.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("key collected");
        } else
        {
            Debug.Log("please collect key");
        }
    }
}
