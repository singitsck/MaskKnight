using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]//必须有Rigidbody
public class Wizard : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Transform target;
    private Animator anim;
    private Transform playerPos;
    float time;
    public float restartDelay;
    private float restartTime;
    private bool WizardRun;
    private bool WizarShoot;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Flip();
        restartTime += Time.deltaTime;
        if(WizardRun==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }

        if (WizarShoot == true && time >= 3)
        {
            GameObject bullet_0 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_0.GetComponent<WizardBullet>().id = 0;

            GameObject bullet_1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_1.GetComponent<WizardBullet>().id = 1;

            GameObject bullet_2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_2.GetComponent<WizardBullet>().id = 2;

            GameObject bullet_3 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_3.GetComponent<WizardBullet>().id = 3;

            GameObject bullet_4 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet_4.GetComponent<WizardBullet>().id = 4;

            StartCoroutine(StartAttackCo());

            time = 0;
        }
        time += Time.deltaTime;
    }

    private void Flip()
    {
        if(transform.position.x> playerPos.position.x)
        {
            Debug.Log("左");
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (transform.position.x < playerPos.position.x)
        {
            Debug.Log("右");
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void Run()
    {
        anim.SetBool("Attack", false);
        anim.SetBool("Run",true);
        WizardRun = true;
        WizarShoot = false;
        Debug.Log("Run");

    }
    public void Attact()
    {
        anim.SetBool("Run", false);
        anim.SetBool("Attack",true);
        WizardRun = false;
        WizarShoot = true;
        Debug.Log("WizardAttack");
    }

    IEnumerator StartAttackCo()
    {
        yield return new WaitForSeconds(2f);
    }
}
