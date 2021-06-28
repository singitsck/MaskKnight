using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip Swing;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }    
    }

    private void Attack()
    {
        AudioSource.PlayClipAtPoint(Swing, transform.position, 30f);
        //mouse position - player position
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius to degree
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        transform.GetChild(0).gameObject.SetActive(true);//開啟子物體
    }
}
