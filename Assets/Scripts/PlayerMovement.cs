using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveH;//水平
    private float moveV;//垂直
    [SerializeField] private float moveSpeed;//player move Speed
    private Animator anim;
    private AudioSource run;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();//get player rigidbody
        run = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal") * moveSpeed;//player move on X * player move Speed
        moveV = Input.GetAxis("Vertical") * moveSpeed;
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
        if(moveV == 0 && moveH == 0)
        {
            run.enabled = false;
            anim.SetBool("Run", false);
        }
        else
        {
            run.enabled = true;
            anim.SetBool("Run", true);
        }

    }

    private void Flip()
    {
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)//角色面左
            transform.eulerAngles = new Vector3(0, 0, 0);
        if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)//角色面右
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
