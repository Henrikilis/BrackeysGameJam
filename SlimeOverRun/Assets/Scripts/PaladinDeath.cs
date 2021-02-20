using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinDeath : MonoBehaviour
{
    public GameObject mainObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime") && mainObject.GetComponent<Paladin>().dead == false)
        {
            mainObject.GetComponent<Paladin>().currentStrength++;
            if (mainObject.GetComponent<Paladin>().currentStrength >= mainObject.GetComponent<Paladin>().strengthNeeded)
            {
                mainObject.GetComponent<Paladin>().ballon.SetActive(false);
                mainObject.GetComponent<Paladin>().text.gameObject.SetActive(false);
                mainObject.GetComponent<Paladin>().anim.SetTrigger("Death");
                mainObject.gameObject.layer = 8;
                mainObject.GetComponent<Paladin>().dead = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime") && mainObject.GetComponent<Paladin>().dead == false)
        {
            mainObject.GetComponent<Paladin>().currentStrength--;
        }
    }
}
