using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] public GameObject StopB;
    [SerializeField] public GameObject PlayB;
    [SerializeField] public GameObject ReferencesBG;

    public void StartGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("nowHp", 0);
    }

    public void Replay()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("nowHp", 0);
        PlayerPrefs.SetInt("ScenesKO", 0);
    }

    public void StopButton()
    {
        StopB.SetActive(false);
        PlayB.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void PlayButton()
    {
        StopB.SetActive(true);
        PlayB.SetActive(false);
        Time.timeScale = 1;   
    }

    public void NextButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }

    public void NextWin()
    {
        SceneManager.LoadScene("Win");
    }

    public void S1()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void S2()
    {
        SceneManager.LoadScene("Scene2");
    }

    public void S3()
    {
        SceneManager.LoadScene("Scene3");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void References()
    {
        ReferencesBG.SetActive(true);
    }

    public void QuitReferences()
    {
        ReferencesBG.SetActive(false);
    }
}
