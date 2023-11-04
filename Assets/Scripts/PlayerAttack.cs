using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip Swing;
    public VariableJoystick variableJoystick;

    public void AttOnClick(){
        Attack();
    }

    private void Attack()
    {
        AudioSource.PlayClipAtPoint(Swing, transform.position, 30f);
        //mouse position - player position
        //Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius to degree
        //transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (variableJoystick.Direction.y < 0){
            if(variableJoystick.Direction.x < 0){
                transform.eulerAngles = new Vector3(0, 0, -90 *(1+0-variableJoystick.Direction.x));
                transform.GetChild(0).gameObject.SetActive(true);
            }
            if(variableJoystick.Direction.x > 0){
                transform.eulerAngles = new Vector3(0, 0, 90 * variableJoystick.Direction.y);
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if (variableJoystick.Direction.y > 0){
            if(variableJoystick.Direction.x > 0){
                transform.eulerAngles = new Vector3(0, 0, 90 * variableJoystick.Direction.y);
                transform.GetChild(0).gameObject.SetActive(true);
            }
            if(variableJoystick.Direction.x < 0){
                transform.eulerAngles = new Vector3(0, 0, 90 *(1+0-variableJoystick.Direction.x));
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        //transform.GetChild(0).gameObject.SetActive(true);//開啟子物體
    }
}
