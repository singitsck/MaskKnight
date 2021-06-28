using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flasks : MonoBehaviour
{
    private float HPflasks;
    public AudioClip deathclip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            if (!player.isAttacked)
            {
                player.HPrecovery(HPflasks);
                AudioSource.PlayClipAtPoint(deathclip, transform.position, 2f);
                Destroy(gameObject);
            }
            
        }
    }
}
