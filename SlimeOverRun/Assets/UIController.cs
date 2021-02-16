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
        sm.accelerate = false;

    }

    public void right()
    {
        sm.moveRight = true;
        //
        sm.moveLeft = false;
        sm.moveUp = false;
        sm.accelerate = false;

    }

    public void halt()
    {
        sm.moveUp = true;
        //
        sm.moveLeft = false;
        sm.moveRight = false;
        sm.accelerate = false;

    }

    public void speed()
    {
        sm.accelerate = true;
        //
        sm.moveLeft = false;
        sm.moveRight = false;
        sm.moveUp = false;

    }
}
