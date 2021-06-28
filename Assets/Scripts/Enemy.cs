using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;//Enemy move Speed
    private Transform target;//追踪target
    [SerializeField] private float maxHp;
    public AudioClip deathclip;
    public float hp;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength;//hurt time持续
    private float timeBtwHurt;//hurt time减少

    [HideInInspector] public bool isAttacked;
    [SerializeField] private GameObject explosionEffect;

    [HideInInspector]
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

        timeBtwHurt -= Time.deltaTime;
        if (timeBtwHurt <= 0)
            sp.material.SetFloat("_FlashAmount", 0);
    }

    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public void TakenDamage(float _amount)
    {
        isAttacked = true;//only run once
        StartCoroutine(isAttackCo());
        hp -= _amount;//Damage number
        HurtShader();

        if (hp <= 0)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathclip, transform.position, 1f);
            Destroy(gameObject);
        }
            
    }

    private void HurtShader()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        timeBtwHurt = hurtLength;
    }

    IEnumerator isAttackCo()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacked = false;
    }
}