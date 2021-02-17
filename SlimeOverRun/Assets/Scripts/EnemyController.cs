using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int strengthNeeded;
    public int currentStrength;
    public bool attacking;

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentStrength++;
            if (currentStrength >= strengthNeeded)
            {
                gameObject.SetActive(false);
            }
            else { StartCoroutine("Attack"); }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentStrength--;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && attacking)
        {
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        attacking = true;
        yield return new WaitForSeconds(.4f);
        attacking = false;
    }
}