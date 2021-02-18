using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public hpbar hp;
    


    void Start()
    {
        hp = FindObjectOfType<hpbar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            hp.decreaseHealth(1);
            other.gameObject.SetActive(false);
        }
    }
}
