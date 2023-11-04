using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public AudioClip Hit;

    [SerializeField] private GameObject explosionEffect;

    public Health healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth<0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamgae(10);
            AudioSource.PlayClipAtPoint(Hit, transform.position, 1f);
            Debug.Log("TakeDamgae");
        }

        if (other.gameObject.tag == "Water")
        {
            TakeDamgae(100);
            Debug.Log("TakeDamgae");
        }
    }

    void TakeDamgae(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
