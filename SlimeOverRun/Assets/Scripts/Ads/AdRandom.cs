using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdRandom : MonoBehaviour
{
    public int rng;
    public GameObject moneyFarm;

    // Start is called before the first frame update
    void Start()
    {
        rng = Random.Range(1, 3);
        if(rng == 2)
        {
            moneyFarm.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
