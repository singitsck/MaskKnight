using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : MonoBehaviour
{
    Wizard WizardMove;

    private void Start()
    {
        WizardMove = GameObject.Find("Wizard").GetComponent<Wizard>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WizardMove.Attact();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            WizardMove.Run();
        }
    }
}
