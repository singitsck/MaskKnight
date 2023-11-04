using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject boomPrefab;
    public GameObject FireInWater;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //销毁炮弹本身
            Destroy(this.gameObject);

            //实例化爆炸效果，在触发的位置和方向
            GameObject.Instantiate(boomPrefab, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);

            GameObject.Instantiate(boomPrefab, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "Water")
        {
            Destroy(this.gameObject);
            GameObject.Instantiate(FireInWater, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "build")
        {
            Destroy(this.gameObject);
            GameObject.Instantiate(boomPrefab, transform.position, transform.rotation);
        }
    }
}
