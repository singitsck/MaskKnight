using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public Transform Turret;
    public Transform Barrel;
    public float mouseSensitivity;
    Vector3 gunRot;
    Vector3 fort;

    void Update()
    {
        gunRot.y += ((Input.mousePosition.x / Screen.width - 0.5f) * 100f - gunRot.y) * 0.1f;
        gunRot.x += ((Input.mousePosition.y / Screen.height - 0.7f) * -20f - gunRot.x) * 0.1f;
        fort.y += ((Input.mousePosition.x / Screen.width - 0.5f) * 100f - gunRot.y) * 0.1f;
        Barrel.localEulerAngles = gunRot;
        Turret.localEulerAngles = fort;
    }
}
