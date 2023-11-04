using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
    public LevelSelection S2;
    public LevelSelection S3;
    public LevelSelection S4;
    public LevelSelection S5;
    public int ScenesKO;

    // Start is called before the first frame update
    void Start()
    {
        S2 = GameObject.Find("S2").GetComponent<LevelSelection>();
        S3 = GameObject.Find("S3").GetComponent<LevelSelection>();
        S4 = GameObject.Find("S4").GetComponent<LevelSelection>();
        S5 = GameObject.Find("S5").GetComponent<LevelSelection>();
    }

    // Update is called once per frame
    void Update() {

        ScenesKO = PlayerPrefs.GetInt("ScenesKO");

        if (ScenesKO >= 1)
        {
            S2.unlocked = true;
        }
        if(ScenesKO >= 2)
        {
            S3.unlocked = true;
        }
        if(ScenesKO >= 3)
        {
            S4.unlocked = true;
        }
        if(ScenesKO >= 4)
        {
            S5.unlocked = true;
        }
    }
}
