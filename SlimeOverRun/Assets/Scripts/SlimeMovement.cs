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
    public bool isGrounded;
    public float flyTime;

    void Start()
    {
        slimeSpeed = initialSlimeSpeed;
        rb = GetComponent<Rigidbody>();
        moveUp = true;
        accelerate = false;
        moveLeft = false;
        moveRight = false;
        moveDown = false;

        isGrounded = true;
    }

    
    void FixedUpdate()
    {

        if(moveUp)
        {
            rb.AddForce(new Vector3(slimeSpeed, 0), ForceMode.Acceleration);
            transform.LookAt(Vector3.back, Vector3.up);
        }

        if (accelerate)
        {
            slimeSpeed = slimeSuperSpeed;
            if(isGrounded)
            model.GetComponent<MeshRenderer>().material = emotion[1];
        }

        if (!accelerate)
        {
            slimeSpeed = initialSlimeSpeed;
            if(isGrounded)
            model.GetComponent<MeshRenderer>().material = emotion[0];
        }

        if (moveLeft)
        {
            rb.AddForce(new Vector3(0, 0, slimeSpeed), ForceMode.Acceleration);
            transform.LookAt(Vector3.left);
        }

        if (moveRight)
        {
            rb.AddForce(new Vector3(0, 0, -slimeSpeed), ForceMode.Acceleration);
            transform.LookAt(Vector3.right);
        }

        if(moveDown)
        {
            rb.AddForce(new Vector3(-slimeSpeed, 0), ForceMode.Acceleration);
            transform.LookAt(Vector3.back);
        }

        if (!isGrounded)
            flyTime += Time.deltaTime;
        if(flyTime > 1)
            model.GetComponent<MeshRenderer>().material = emotion[2];
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            flyTime = 0;
        }
    }

}
