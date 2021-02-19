using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{

    public Rigidbody rb;
    [SerializeField]
    private float slimeSpeed;
    public float initialSlimeSpeed;
    public float slimeSuperSpeed;

    public bool moveUp;
    public bool accelerate;
    public bool moveLeft;
    public bool moveRight;
    public bool moveDown;

    public Material[] emotion;
    public GameObject model;

    void Start()
    {
        slimeSpeed = initialSlimeSpeed;
        rb = GetComponent<Rigidbody>();
        moveUp = true;
        accelerate = false;
        moveLeft = false;
        moveRight = false;
        moveDown = false;
    }

    
    void FixedUpdate()
    {

        if(moveUp)
        {
            rb.AddForce(new Vector3(slimeSpeed, 0), ForceMode.Acceleration);
        }

        if (accelerate)
        {
            slimeSpeed = slimeSuperSpeed;
            model.GetComponent<MeshRenderer>().material = emotion[1];
        }

        if (!accelerate)
        {
            slimeSpeed = initialSlimeSpeed;
            model.GetComponent<MeshRenderer>().material = emotion[0];
        }

        if (moveLeft)
        {
            rb.AddForce(new Vector3(0, 0, slimeSpeed), ForceMode.Acceleration);
        }

        if (moveRight)
        {
            rb.AddForce(new Vector3(0, 0, -slimeSpeed), ForceMode.Acceleration);
        }

        if(moveDown)
        {
            rb.AddForce(new Vector3(-slimeSpeed, 0), ForceMode.Acceleration);
        }

        if(rb.velocity.y != 0)
        {
            model.GetComponent<MeshRenderer>().material = emotion[2];
        }
    }

}
