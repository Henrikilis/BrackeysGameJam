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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        passedPointA = false;
        passedPointB = false;
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
}
