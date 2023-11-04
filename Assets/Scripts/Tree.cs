using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public AudioClip TreeDown;

    void OnTriggerEnter(Collider other)
    {
        if(other .gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(TreeDown, transform.position, 1f);
        }
    }
}
