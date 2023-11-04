using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveH;//水平
    private float moveV;//垂直

    public GameObject shell;
    public Transform FireStart;
    public float shellSpeed = 50;
    public GameObject OpenFire;
    public float moveSpeed = 5f;
    public float rotateSpeed = 20f;
    private AudioSource Engine;
    public AudioClip Fire;

    Vector3 moveAmount;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Engine = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;//player move on X * player move Speed
        moveV = Input.GetAxis("Vertical") * moveSpeed;

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);

        if (moveV == 0 && moveH == 0)
        {
            Engine.enabled = false;
        }
        else
        {
            Engine.enabled = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Instantiate(OpenFire, FireStart.position, FireStart.rotation);
            AudioSource.PlayClipAtPoint(Fire,transform.position, 1f);
            GameObject fireInstance = GameObject.Instantiate(shell, FireStart.position, FireStart.rotation);
            fireInstance.GetComponent<Rigidbody>().velocity = fireInstance.transform.forward * shellSpeed;
        }
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + moveAmount);
    }
}