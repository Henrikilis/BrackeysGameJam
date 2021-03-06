﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public AudioClip warriorDeath;
    public AudioClip slimeDeath;

    public GameObject ballon;
    private int displayText;
    public TMP_Text text;
    public AudioSource audioClip;
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
        hp = FindObjectOfType<hpbar>();
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
                audioClip.clip = warriorDeath;
                audioClip.Play();
                ballon.SetActive(false);
                text.gameObject.SetActive(false);
                anim.SetTrigger("Death");
                gameObject.layer = 8;
                dead = true;
            }
            else { StartCoroutine("Attack"); }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MainSlime") && !dead)
        {
            currentStrength--;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && attacking && !dead)
        {
            audioClip.clip = slimeDeath;
            audioClip.Play();
            hp.decreaseHealth(1);
            other.gameObject.SetActive(false);
            currentStrength--;
        }
        if (other.CompareTag("MainSlime") && attacking && !dead)
        {
            hp.decreaseHealth(1);
            audioClip.clip = slimeDeath;
            audioClip.Play();
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