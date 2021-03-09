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
}
