using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public SlimeMovement sm;

    private void Start()
    {
        sm = FindObjectOfType<SlimeMovement>();
    }

    public void left()
    {
        sm.moveLeft = true;
        //
        sm.moveRight = false;
        sm.moveUp = false;
        sm.moveDown = false;

    }

    public void right()
    {
        sm.moveRight = true;
        //
        sm.moveLeft = false;
        sm.moveUp = false;
        sm.moveDown = false;

    }

    public void halt()
    {
        sm.accelerate = false;

    }

    public void up()
    {
        sm.moveUp = true;
        //
        sm.moveDown = false;
        sm.moveLeft = false;
        sm.moveRight = false;


    }

    public void down()
    {
        sm.moveDown = true;
        //
        sm.moveUp = false;
        sm.moveLeft = false;
        sm.moveRight = false;
        

    }

    public void speed()
    {
        sm.accelerate = true;       
    }
}
