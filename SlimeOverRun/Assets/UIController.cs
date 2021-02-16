using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public  SlimeMovement [] sm;

    private void Start()
    {
        sm = FindObjectsOfType<SlimeMovement>();
    }

    public void left()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].moveLeft = true;
            sm[i].moveRight = false;
            sm[i].moveUp = false;
            sm[i].moveDown = false;
        }
        
        
       

    }

    public void right()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].moveRight = true;
            sm[i].moveLeft = false;
            sm[i].moveUp = false;
            sm[i].moveDown = false;
        }

    }

    public void halt()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].accelerate = false;
        }
        

    }

    public void up()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].moveRight = false;
            sm[i].moveLeft = false;
            sm[i].moveUp = true;
            sm[i].moveDown = false;
        }

    }

    public void down()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].moveRight = false;
            sm[i].moveLeft = false;
            sm[i].moveUp = false;
            sm[i].moveDown = true;
        }

    }

    public void speed()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].accelerate = true;
        }
    }
}
