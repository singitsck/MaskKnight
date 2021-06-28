using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    LevelSelection S2;
    LevelSelection S3;
    public int ScenesKO;

    // Start is called before the first frame update
    void Start()
    {
        S2 = GameObject.Find("S2").GetComponent<LevelSelection>();
        S3 = GameObject.Find("S3").GetComponent<LevelSelection>();
    }

    // Update is called once per frame
    void Update()
    {
        ScenesKO = PlayerPrefs.GetInt("ScenesKO");

        if (ScenesKO > 0)
        {
            Debug.Log("S2open");
            S2.unlocked = true;
        }
        if(ScenesKO > 1)
        {
            S3.unlocked = true;
        }
    }
}
