using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public bool unlocked;
    public Image lockImage;

    // Update is called once per frame
    void Update()
    {
        UpdateLevelImage();
    }

    private void UpdateLevelImage()
    {
        if(unlocked==true)
        {
            lockImage.gameObject.SetActive(false);
            this.GetComponent<Image>().color = new Color(255, 255, 255);
            this.GetComponent<Button>().enabled = true;
        }
        else
        {
            lockImage.gameObject.SetActive(true);
            this.GetComponent<Image>().color = Color.grey;
            this.GetComponent<Button>().enabled = false;
        }
    }


}
