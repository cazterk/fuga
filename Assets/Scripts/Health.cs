using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    public Animator animator;

    const string PLAYER_DEAD = "player_dead";
    const string PLAYER_HIT = "player_hit";
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void changeAnimationState(string newState)
    {
        animator.Play(newState);
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        changeAnimationState(PLAYER_HIT);

        if (currentHealth <= 0)
        {
            // we are dead
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            changeAnimationState(PLAYER_DEAD);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }
}
