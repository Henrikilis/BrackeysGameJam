using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour
{

    public SlimeMovement[] sm;

    [SerializeField]
    private float slimeCount;

    public  float slimeToWin;
    private float slimeTotal;




    void Start()
    {
        sm = FindObjectsOfType<SlimeMovement>();

        for (int i = 0; i < sm.Length; i++)
        {
            slimeTotal++;
        }

        slimeToWin = slimeTotal / 3;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            slimeCount++;
            if (slimeCount >= slimeToWin)
            {
                //passa de fase
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            slimeCount--;
        }
    }
}
