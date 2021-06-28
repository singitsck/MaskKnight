using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{

    [SerializeField] private float minDamage;//最小Damage
    [SerializeField] private float maxDamage;//最大Damage
    private float attackDamage;
    public AudioClip hit;

    public GameObject damageCanvas;

    public void EndAttack()
    {
        gameObject.SetActive(false);//关闭Slash
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            attackDamage = Random.Range(minDamage, maxDamage);

            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if(!enemy.isAttacked)
            {
                StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.1f, 0.1f));

                enemy.TakenDamage(attackDamage);
                AudioSource.PlayClipAtPoint(hit, transform.position, 10f);

                //MARKER SHOW damage Number
                DamageNum damagable = Instantiate(damageCanvas, other.transform.position, Quaternion.identity).GetComponent<DamageNum>();
                damagable.ShowDamage(Mathf.RoundToInt(attackDamage));

                #region 擊退效果反方向移動，從角色中心點“當前位置”向敵人位置方向“目標點”移動
                Vector2 difference = other.transform.position - transform.position;
                other.transform.position = new Vector2(other.transform.position.x + difference.x / 2,
                                                       other.transform.position.y + difference.y / 2);
                #endregion
            }
        }
    }

}
