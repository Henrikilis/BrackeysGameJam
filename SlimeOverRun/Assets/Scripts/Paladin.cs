using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Paladin : MonoBehaviour
{
    public AudioSource audioClip;
    public AudioClip PaladinDeath, SlimeDeath;

    public int strengthNeeded;
    public int currentStrength;
    public bool attacking;
    public bool dead;
    public hpbar hp;
    public slimeManager sm;
    Camera cam;
    public Animator anim;

    public GameObject ballon;
    private int displayText;
    public TMP_Text text;

    // Update is called once per frame
    void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        hp = FindObjectOfType<hpbar>();
        sm = FindObjectOfType<slimeManager>();
    }

    private void Update()
    {
        displayText = strengthNeeded - currentStrength;
        hp = FindObjectOfType<hpbar>();
        text.SetText(displayText.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime") && !dead)
        {
            anim.SetTrigger("Attack");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && attacking && !dead)
        {
            hp.decreaseHealth(1);
            audioClip.clip = SlimeDeath;
            audioClip.Play();
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("MainSlime") && attacking && !dead)
        {
            hp.decreaseHealth(1);
            audioClip.clip = SlimeDeath;
            audioClip.Play();
            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();
        }
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