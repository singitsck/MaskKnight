using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public void ReplayButton()
    {
        SceneManager.LoadScene("Arras");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
