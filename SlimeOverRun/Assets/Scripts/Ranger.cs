using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranger : MonoBehaviour
{
    public AudioSource audioClip;
    public Animator anim;
    public int strengthNeeded;
    public int currentStrength;
    public bool dead;
    public GameObject bow;

    public GameObject ballon;
    private int displayText;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        displayText = strengthNeeded - currentStrength;

        text.SetText(displayText.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !dead)
        {
            currentStrength++;
            if (currentStrength >= strengthNeeded)
            {
                audioClip.Play();
                ballon.SetActive(false);
                text.gameObject.SetActive(false);
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
