using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] Hearts _hearts;
    [SerializeField] int damage;
    public Animator animator;

    const string PLAYER_DEAD = "player_dead";
    const string PLAYER_HIT = "player_hit";
    // Start is called before the first frame update
    
    void changeAnimationState(string newState)
    {
        animator.Play(newState);
    }

    void TakeDamage()
    {
        _hearts.playerHealth = _hearts.playerHealth - damage;
        _hearts.UpdateHealth();

        changeAnimationState(PLAYER_HIT);

        if (_hearts.playerHealth <= 0)
        {
            // player dead
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            changeAnimationState(PLAYER_DEAD);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage();
            Debug.Log("player hit");
        }
    }
}
