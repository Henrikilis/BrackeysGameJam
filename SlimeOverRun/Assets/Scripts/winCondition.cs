using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour
{

    public SlimeMovement[] sm;
    public slimeManager manager;

    [SerializeField]
    private float slimeCount;

    public  float slimeToWin;
    private float slimeTotal;

    public int myLevel;


    void Start()
    {
        sm = FindObjectsOfType<SlimeMovement>();
        manager = FindObjectOfType<slimeManager>();

        for (int i = 0; i < sm.Length; i++)
        {
            slimeTotal++;
        }

        slimeToWin = 1;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime"))
        {
            slimeCount++;
            if (manager.currentSlimes == 5)
            {
                if(myLevel == 0)
                    LevelScore.lvl0 = 1;
                if (myLevel == 1)
                    LevelScore.lvl1 = 1;
                if (myLevel == 2)
                    LevelScore.lvl2 = 1;
                if (myLevel == 3)
                    LevelScore.lvl3 = 1;
                if (myLevel == 4)
                    LevelScore.lvl4 = 1;
                if (myLevel == 5)
                    LevelScore.lvl5 = 1;
                if (myLevel == 6)
                    LevelScore.lvl6 = 1;
            }
            if (manager.currentSlimes > 5 && manager.currentSlimes < 10)
            {
                if (myLevel == 0)
                    LevelScore.lvl0 = 2;
                if (myLevel == 1)
                    LevelScore.lvl1 = 2;
                if (myLevel == 2)
                    LevelScore.lvl2 = 2;
                if (myLevel == 3)
                    LevelScore.lvl3 = 2;
                if (myLevel == 4)
                    LevelScore.lvl4 = 2;
                if (myLevel == 5)
                    LevelScore.lvl5 = 2;
                if (myLevel == 6)
                    LevelScore.lvl6 = 2;
            }
            if (manager.currentSlimes == 10)
            {
                if (myLevel == 0)
                    LevelScore.lvl0 = 3;
                if (myLevel == 1)
                    LevelScore.lvl1 = 3;
                if (myLevel == 2)
                    LevelScore.lvl2 = 3;
                if (myLevel == 3)
                    LevelScore.lvl3 = 3;
                if (myLevel == 4)
                    LevelScore.lvl4 = 3;
                if (myLevel == 5)
                    LevelScore.lvl5 = 3;
                if (myLevel == 6)
                    LevelScore.lvl6 = 3;
            }
            CheckBest();
            if (slimeCount >= slimeToWin)
            {
                manager.NextLevel();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime"))
        {
            slimeCount--;
        }
    }

    public void CheckBest()
    {
        if (LevelScore.lvl0 > LevelScore.pb0)
            LevelScore.pb0 = LevelScore.lvl0;
        if (LevelScore.lvl1 > LevelScore.pb1)
            LevelScore.pb1 = LevelScore.lvl1;
        if (LevelScore.lvl2 > LevelScore.pb2)
            LevelScore.pb2 = LevelScore.lvl2;
        if (LevelScore.lvl3 > LevelScore.pb3)
            LevelScore.pb3 = LevelScore.lvl3;
        if (LevelScore.lvl4 > LevelScore.pb4)
            LevelScore.pb4 = LevelScore.lvl4;
        if (LevelScore.lvl5 > LevelScore.pb5)
            LevelScore.pb5 = LevelScore.lvl5;
        if (LevelScore.lvl6 > LevelScore.pb6)
            LevelScore.pb6 = LevelScore.lvl6;

        PlayerPrefs.SetInt("pb0", LevelScore.pb0);
        PlayerPrefs.SetInt("pb1", LevelScore.pb1);
        PlayerPrefs.SetInt("pb2", LevelScore.pb2);
        PlayerPrefs.SetInt("pb3", LevelScore.pb3);
        PlayerPrefs.SetInt("pb4", LevelScore.pb4);
        PlayerPrefs.SetInt("pb5", LevelScore.pb5);
        PlayerPrefs.SetInt("pb6", LevelScore.pb6);
    }
}
