using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator anim;
    public GameObject connection;
    public int weightNeeded;
    public int currentWeight;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            currentWeight++;
            if(currentWeight >= weightNeeded)
            {
                connection.GetComponent<Interactable>().GotTriggered();
                anim.SetTrigger("Triggered");
                Debug.Log("Pisei");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentWeight--;
        }
    }
}
