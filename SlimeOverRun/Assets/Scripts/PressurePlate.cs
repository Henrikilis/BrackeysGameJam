using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PressurePlate : MonoBehaviour
{
    public Animator anim;
    public GameObject connection;
    public int weightNeeded;
    public int currentWeight;

    private int displayText;

    public GameObject ballon;

    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        displayText = weightNeeded - currentWeight;

        text.SetText(displayText.ToString());

        

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            currentWeight++;
            if(currentWeight >= weightNeeded)
            {
                ballon.SetActive(false);
                text.gameObject.SetActive(false);
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
