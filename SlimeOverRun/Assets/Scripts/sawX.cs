using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawX : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource audioClip;

    public Transform pointA;
    public Transform pointB;

    public float sawSpeed;

    public bool passedPointB;
    public bool passedPointA;

    public slimeManager sm;
    public hpbar hp;
    Camera cam;

    void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        hp = FindObjectOfType<hpbar>();
        rb = GetComponent<Rigidbody>();
        passedPointA = false;
        passedPointB = false;
        //hp = FindObjectOfType<hpbar>();

        sm = FindObjectOfType<slimeManager>();
    }


    void FixedUpdate()
    {
        hp = FindObjectOfType<hpbar>();

        if (this.gameObject.transform.position.x < pointA.position.x)
            rb.AddForce(new Vector3(sawSpeed, 0, 0), ForceMode.Acceleration);

        else if (this.gameObject.transform.position.x > pointA.position.x)
        {
            passedPointA = true;
        }

        if (this.gameObject.transform.position.x > pointB.position.x && passedPointA)
            rb.AddForce(new Vector3(-sawSpeed, 0, 0), ForceMode.Acceleration);
        else if (this.gameObject.transform.position.x < pointB.position.x)
        {
            passedPointB = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hp.decreaseHealth(1);
            audioClip.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("MainSlime"))
        {
            hp.decreaseHealth(1);
            audioClip.Play();
            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();
        }
    }
}
