using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }
    }
}
