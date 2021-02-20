using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mage : MonoBehaviour
{
    public Animator anim;
    public int strengthNeeded;
    public int currentStrength;
    public bool dead;

    public GameObject ballon;
    private int displayText;
    public TMP_Text text;

    public GameObject buff;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        if (!dead)
        {
            buff.GetComponent<EnemyController>().strengthNeeded = buff.GetComponent<EnemyController>().strengthNeeded * 2;
            buff.GetComponent<EnemyController>().text.color = Color.red;
        }
    }

    private void Update()
    {
        displayText = strengthNeeded - currentStrength;

        text.SetText(displayText.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime") && !dead)
        {
            currentStrength++;
            if (currentStrength >= strengthNeeded)
            {
                ballon.SetActive(false);
                text.gameObject.SetActive(false);
                anim.SetTrigger("Death");
                gameObject.layer = 8;
                dead = true;
                buff.GetComponent<EnemyController>().strengthNeeded = buff.GetComponent<EnemyController>().strengthNeeded / 2;
                buff.GetComponent<EnemyController>().text.color = Color.white;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime") && !dead)
        {
            currentStrength--;
        }
    }
}
