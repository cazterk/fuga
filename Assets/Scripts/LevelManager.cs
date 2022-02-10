using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D finishLevel)
    {

        var keyCollected = finishLevel.gameObject.GetComponent<Player>().KeyCollect(true);

        if ( keyCollected && finishLevel.CompareTag("Player"))
        {
            Debug.Log("key collected");
        } else
        {
            Debug.Log("please collect key");
        }
    }
}
