﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public slimeManager sm;
    public hpbar hp;
    Camera cam;

    public bool arrow;
    public Rigidbody rb;

    void Start()
    {
        hp = FindObjectOfType<hpbar>();
        sm = FindObjectOfType<slimeManager>();
        if (arrow)
            rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(arrow)
            rb.AddForce(new Vector3(-10, 0), ForceMode.Acceleration);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hp.decreaseHealth(1);
            other.gameObject.SetActive(false);
            if (arrow)
                Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("MainSlime"))
        {
            hp.decreaseHealth(1);

            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();
        }
        if (other.gameObject.CompareTag("Untagged"))
        {
            if (arrow)
                Destroy(gameObject);
        }
    }
}