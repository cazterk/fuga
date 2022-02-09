using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip player_footstep, player_hurt, player_jump_hop, collectable, shoot;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player_footstep = Resources.Load<AudioClip>("player_footstep");
        player_hurt = Resources.Load<AudioClip>("player_hurt");
        player_jump_hop = Resources.Load<AudioClip>("player_jump_hop");
        collectable = Resources.Load<AudioClip>("collectable");
        shoot = Resources.Load<AudioClip>("shoot");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSource.PlayOneShot(shoot);
                break;
            case "player_footstep":
                audioSource.PlayOneShot(player_footstep);
                break;
            case "player_jump_hop":
                audioSource.PlayOneShot(player_jump_hop);
                break;
            case "player_hurt":
                audioSource.PlayOneShot(player_hurt);
                break;
            case "collectable":
                audioSource.PlayOneShot(collectable);
                break;

        }
    }
}
