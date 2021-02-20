using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public slimeManager sm;
    public hpbar hp;
    Camera cam;


    void Start()
    {
        hp = FindObjectOfType<hpbar>();
        sm = FindObjectOfType<slimeManager>();
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
        if (other.gameObject.CompareTag("MainSlime"))
        {
             hp.decreaseHealth(1);
            
            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();
        }
    }
}
