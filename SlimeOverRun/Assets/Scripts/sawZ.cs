using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawZ : MonoBehaviour
{

    public Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
        passedPointA = false;
        passedPointB = false;

        hp = FindObjectOfType<hpbar>();
        sm = FindObjectOfType<slimeManager>();
    }

   
    void FixedUpdate()
    {
        if (this.gameObject.transform.position.z < pointA.position.z)
            rb.AddForce(new Vector3(0, 0, sawSpeed), ForceMode.Acceleration);
        
        else if (this.gameObject.transform.position.z > pointA.position.z)
        {
            passedPointA = true;
        }

        if (this.gameObject.transform.position.z > pointB.position.z && passedPointA)
            rb.AddForce(new Vector3(0, 0, -sawSpeed), ForceMode.Acceleration);
        else if (this.gameObject.transform.position.z < pointB.position.z)
        {
            passedPointB = true;
        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hp.decreaseHealth(1);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("MainSlime"))
        {
            hp.decreaseHealth(1);

            cam = other.gameObject.GetComponentInChildren<Camera>();
            cam.gameObject.transform.parent = null;
            other.gameObject.SetActive(false);
            sm.isDead();
        }
    }
}
