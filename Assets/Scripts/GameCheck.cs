using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCheck : MonoBehaviour
{
    [SerializeField] public GameObject GameClear;
    [SerializeField] public GameObject GameOver;
    [SerializeField] public GameObject BackButton;
    [SerializeField] public GameObject StopB;
    [SerializeField] public GameObject PlayB;
    [SerializeField] public GameObject NextB;
    public int ScenesKO,nowScenes;
    private GameObject[] EnemyNo;
    private GameObject[] PlayerNo;
    public float restartDelay;
    private float restartTime;

    private void Start()
    {
        ScenesKO = PlayerPrefs.GetInt("ScenesKO");
    }

    public void Update()
    {
        EnemyNo = GameObject.FindGameObjectsWithTag("Enemy"); //查找所有关于Enemy标签的物件，保存到数组EnemyNo
        PlayerNo = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < EnemyNo.Length; i++)  //遍历数组，输出物件的名称
        {
            Debug.Log (EnemyNo[i].name);
        }

        for (int i = 0; i < PlayerNo.Length; i++)  //遍历数组，输出物件的名称
        {
            Debug.Log(PlayerNo[i].name);
        }
    }
    private void FixedUpdate()
    {
        if (EnemyNo.Length <= 0)
        {
            StopB.SetActive(false);
            PlayB.SetActive(false);
            restartTime += Time.deltaTime;
            if (restartTime >= restartDelay)
            {
                Debug.Log("GameWin");
                GameObject.Find("Slash Point").GetComponent<PlayerAttack>().enabled = false;
                GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
                GameClear.SetActive(true);
                BackButton.SetActive(true);
                NextB.SetActive(true);
                if(ScenesKO <= nowScenes){
                    ScenesKO += 1;
                    PlayerPrefs.SetInt("ScenesKO", ScenesKO);
                }
                GameObject.Find("GameCheck").GetComponent<GameCheck>().enabled = false;
            }
            
        }

        if (PlayerNo.Length <= 0)
        {
            StopB.SetActive(false);
            PlayB.SetActive(false);
            restartTime += Time.deltaTime;
            if (restartTime >= restartDelay)
            {
                Debug.Log("GameOver");
                GameOver.SetActive(true);
                BackButton.SetActive(true);
            }
            
        }
    }
}
