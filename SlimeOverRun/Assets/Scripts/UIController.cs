using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public AudioSource audioClip;
    public  SlimeMovement [] sm;
    public Sprite[] arrow;
    public GameObject[] directions;
    public Sprite[] speeds;
    public GameObject button;
    
   

    private void Start()
    {
        audioClip = gameObject.GetComponent<AudioSource>();
        sm = FindObjectsOfType<SlimeMovement>();
        directions[2].GetComponent<Image>().sprite = arrow[1];
    }

    public void left()
    {
        audioClip.Play();

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
        audioClip.Play();
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
            if (!sm[i].accelerate) { 
                sm[i].accelerate = true;
                button.GetComponent<Image>().sprite = speeds[0];
            }
            else if (sm[i].accelerate) { 
                sm[i].accelerate = false;
                button.GetComponent<Image>().sprite = speeds[1];
            }
        }
        

    }

    public void up()
    {
        audioClip.Play();
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
        audioClip.Play();
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
