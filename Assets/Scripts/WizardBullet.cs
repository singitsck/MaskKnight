using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : MonoBehaviour
{
    [HideInInspector] public int id;
    [SerializeField] private float bulletSpeed = 10f;

    public GameObject BulletEffect;

    public void Update()
    {
        if (id == 0)
            transform.Translate(-bulletSpeed * Time.deltaTime, bulletSpeed * Time.deltaTime, 0);
        if (id == 2)
            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position, bulletSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Instantiate(BulletEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            Instantiate(BulletEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
