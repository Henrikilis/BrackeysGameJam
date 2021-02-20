using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    public Animator anim;
    public int strengthNeeded;
    public int currentStrength;
    public bool dead;
    public GameObject bow;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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

    void CallAnimationShot()
    {
        bow.GetComponent<RangerFire>().ShootArrow();
    }
}
