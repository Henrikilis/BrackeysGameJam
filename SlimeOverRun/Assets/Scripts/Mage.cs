using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : MonoBehaviour
{
    public Animator anim;
    public int strengthNeeded;
    public int currentStrength;
    public bool dead;

    public GameObject buff;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (!dead)
            buff.GetComponent<EnemyController>().strengthNeeded = buff.GetComponent<EnemyController>().strengthNeeded * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dead)
        {
            currentStrength++;
            if (currentStrength >= strengthNeeded)
            {
                anim.SetTrigger("Death");
                gameObject.layer = 8;
                dead = true;
                buff.GetComponent<EnemyController>().strengthNeeded = buff.GetComponent<EnemyController>().strengthNeeded / 2;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !dead)
        {
            currentStrength--;
        }
    }
}
