using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class tutorialTextScript : MonoBehaviour
{
    public TMP_Text Tutorialtext;

    void Start()
    {
        Tutorialtext.SetText("Use the Buttons on the Screen to Move!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pressurePlateText")
        {
            Tutorialtext.SetText("Step on the Pressure Plate with enough Slimes to Open doors!");
            other.gameObject.SetActive(false);

        }
        if(other.tag == "ponteText")
        {
            Tutorialtext.SetText("Pressure Plates can also raise bridges!");
            other.gameObject.SetActive(false);

        }
        if (other.tag == "inimigoText")
        {
            Tutorialtext.SetText("overwhelm Enemies with your Slimes to kill them!");
            other.gameObject.SetActive(false);

        }
    }
}
