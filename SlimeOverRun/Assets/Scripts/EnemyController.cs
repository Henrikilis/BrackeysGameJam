using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int strengthNeeded;
    public int currentStrength;
    public bool attacking;
    public bool dead;
    public hpbar hp;
    public slimeManager sm;
    Camera cam;
    public Animator anim;

    // Update is called once per frame
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        hp = FindObjectOfType<hpbar>();
        sm = FindObjectOfType<slimeManager>();
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
            else { StartCoroutine("Attack"); }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !dead)
        {
            currentStrength--;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && attacking && !dead)
        {
            hp.decreaseHealth(1);
            other.gameObject.SetActive(false);
            currentStrength--;
        }
        if (other.CompareTag("MainSlime") && attacking && !dead)
        {
            hp.decreaseHealth(1);

            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Attack");
    }
    public void StartAttack()
    {
        attacking = true;
    }
    public void EndAttack()
    {
        attacking = false;
    }
}