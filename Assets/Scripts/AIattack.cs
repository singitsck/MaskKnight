using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIattack : MonoBehaviour
{
    private float AIattackDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
            if (!player.isAttacked)
            {
                player.TakenDamage(AIattackDamage);

            }
        }   
    }
}
