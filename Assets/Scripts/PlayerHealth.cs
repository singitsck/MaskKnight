using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int hp;
    [SerializeField] private int nowHp;

    public bool isAttacked;
    public bool isAttack { get { return isAttacked; } set { isAttacked = value; } }

    private Animator anim;
    public AudioClip hurt;

    public Image[] hearts;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength;//hurt time持续
    private float timeBtwHurt;//hurt time减少

    private void Start()
    {
        nowHp = PlayerPrefs.GetInt("nowHp");
        hp = maxHp +nowHp;
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    public void TakenDamage(float _amount)
    {
        if (!isAttack)
        {
            anim.SetTrigger("isHurt");
            AudioSource.PlayClipAtPoint(hurt, transform.position, 1f);
            hp--;
            nowHp--;
            PlayerPrefs.SetInt("nowHp", nowHp);
            StartCoroutine(InvincibleCo());
            HurtShader();
            Debug.Log("Player Hurt");

        }

    }

    public void HPrecovery(float _amount)
    {
        if (!isAttack)
        {
            anim.SetTrigger("isHurt");
            hp++;
            nowHp++;
            PlayerPrefs.SetInt("nowHp", nowHp);
            StartCoroutine(InvincibleCo());
            HurtShader();
            Debug.Log("Player HP recovery");

        }

    }

    public void Update()
    {
        if (timeBtwHurt <= 0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
        }
        else
        {
            timeBtwHurt -= Time.deltaTime;
        }

        for (int i = 0;i < hearts.Length;i++)//hearts Image
        {
            if(i<hp)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(hp<=0)
        {
            Destroy(gameObject);
        }
    }

    private void HurtShader()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        timeBtwHurt = hurtLength;
    }

    IEnumerator InvincibleCo()
    {
        isAttack = true;
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
    }
}
