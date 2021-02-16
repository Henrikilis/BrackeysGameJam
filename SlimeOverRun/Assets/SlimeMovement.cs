using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float slimeSpeed;
    public float slimeSuperSpeed;

    public bool moveUp;
    public bool accelerate;
    public bool moveLeft;
    public bool moveRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveUp = false;
        accelerate = false;
        moveLeft = false;
        moveRight = false;
    }

    
    void FixedUpdate()
    {

        if(moveUp)
        rb.AddForce(new Vector3(slimeSpeed, 0), ForceMode.Acceleration);

        if (accelerate)
        rb.AddForce(new Vector3(slimeSuperSpeed, 0), ForceMode.Acceleration);

        if (moveLeft)
        rb.AddForce(new Vector3(0, 0, slimeSpeed), ForceMode.Acceleration);

        if (moveRight)
        rb.AddForce(new Vector3(0, 0, -slimeSpeed), ForceMode.Acceleration);

    }

}
