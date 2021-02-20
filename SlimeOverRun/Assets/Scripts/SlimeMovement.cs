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


    [SerializeField]
    private Transform lookPosFrente;
    [SerializeField]
    private Transform lookPosTras;
    [SerializeField]
    private Transform lookPosEsquerda;
    [SerializeField]
    private Transform lookPosDireita;


    public Material[] emotion;
    public GameObject model;
    public bool isGrounded;
    public float flyTime;
    private Vector3 direction;

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

            Vector3 direction = lookPosFrente.position - model.transform.position;

            model.transform.rotation = Quaternion.LookRotation(direction);
       
            
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

            Vector3 direction = lookPosEsquerda.position - model.transform.position;

            model.transform.rotation = Quaternion.LookRotation(direction);

        }

        if (moveRight)
        {
            rb.AddForce(new Vector3(0, 0, -slimeSpeed), ForceMode.Acceleration);

            Vector3 direction = lookPosDireita.position - model.transform.position;

            model.transform.rotation = Quaternion.LookRotation(direction);


        }

        if(moveDown)
        {
            rb.AddForce(new Vector3(-slimeSpeed, 0), ForceMode.Acceleration);
            

            Vector3 direction = lookPosTras.position - model.transform.position;

            model.transform.rotation = Quaternion.LookRotation(direction);


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
