using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public  SlimeMovement [] sm;
    public Sprite[] arrow;
    public GameObject[] directions;

    private void Start()
    {
        sm = FindObjectsOfType<SlimeMovement>();
        directions[2].GetComponent<Image>().sprite = arrow[1];
    }

    public void left()
    {
        for (int i = 0; i < sm.Length; i++)
        {
            sm[i].moveLeft = true;
            sm[i].moveRight = false;
            sm[i].moveUp = false;
            sm[i].moveDown = false;

            directions[0].GetComponent<Image>().sprite = arrow[1];
            directions[1].GetComponent<Image>().sprite = arrow[0];
            directions[2].GetComponent<Image>().sprite = arrow[0];
            directions[3].GetComponent<Image>().sprite = arrow[0];
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

            directions[0].GetComponent<Image>().sprite = arrow[0];
            directions[1].GetComponent<Image>().sprite = arrow[1];
            directions[2].GetComponent<Image>().sprite = arrow[0];
            directions[3].GetComponent<Image>().sprite = arrow[0];
        }

    }

    public void swapSpeed()
    {
        
        for (int i = 0; i < sm.Length; i++)
        {
            if (!sm[i].accelerate)
                sm[i].accelerate = true;
            else if(sm[i].accelerate)
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

            directions[0].GetComponent<Image>().sprite = arrow[0];
            directions[1].GetComponent<Image>().sprite = arrow[0];
            directions[2].GetComponent<Image>().sprite = arrow[1];
            directions[3].GetComponent<Image>().sprite = arrow[0];
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

            directions[0].GetComponent<Image>().sprite = arrow[0];
            directions[1].GetComponent<Image>().sprite = arrow[0];
            directions[2].GetComponent<Image>().sprite = arrow[0];
            directions[3].GetComponent<Image>().sprite = arrow[1];
        }

    }

}
