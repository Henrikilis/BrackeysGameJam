using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.Find("Buttons");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            buttons.GetComponent<UIController>().up();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttons.GetComponent<UIController>().down();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            buttons.GetComponent<UIController>().left();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttons.GetComponent<UIController>().right();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttons.GetComponent<UIController>().swapSpeed();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            buttons.GetComponent<slimeManager>().PauseMenuButton();
        }
    }
}
