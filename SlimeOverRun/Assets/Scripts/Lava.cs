using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public AudioSource audioClip;
    public AudioClip lavaDeath, arrowDeath;
    public slimeManager sm;
    public hpbar hp;
    public tutorialTextScript tts;
    Camera cam;

    public bool arrow;
    public Rigidbody rb;

    void Start()
    {
        tts = GetComponent<tutorialTextScript>();
        audioClip = gameObject.GetComponent<AudioSource>();
        hp = FindObjectOfType<hpbar>();
        sm = FindObjectOfType<slimeManager>();
        if (arrow)
            rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        hp = FindObjectOfType<hpbar>();
        if (arrow)
            rb.AddForce(gameObject.transform.forward * 2.5f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tts.Tutorialtext.SetText("Ouch!  Slimes really don't like Lava!");

            hp.decreaseHealth(1);
            other.gameObject.SetActive(false);

            if (!arrow)
            {
                audioClip.clip = lavaDeath;
                audioClip.Play();
            }         
            
            if (arrow)
            {
                audioClip.clip = arrowDeath;
                audioClip.Play();
                Destroy(gameObject);              
            }
               
        }
        if (other.gameObject.CompareTag("MainSlime"))
        {
            hp.decreaseHealth(1);
            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();

            if (!arrow)
            {
                audioClip.clip = lavaDeath;
                audioClip.Play();
            }

            if (arrow)
            {
                audioClip.clip = arrowDeath;
                audioClip.Play();
                Destroy(gameObject);
            }
        }
        if (other.gameObject.CompareTag("Untagged"))
        {
            if (arrow)
                Destroy(gameObject);
        }
    }
}