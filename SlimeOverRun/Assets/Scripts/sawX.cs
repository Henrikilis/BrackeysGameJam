using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawX : MonoBehaviour
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
}
