using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int[] lvl;

    public Image[] img;

    public Sprite[] stars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img[0].GetComponent<Image>().sprite = stars[lvl[0]];
        img[1].GetComponent<Image>().sprite = stars[lvl[1]];
        img[2].GetComponent<Image>().sprite = stars[lvl[2]];
        img[3].GetComponent<Image>().sprite = stars[lvl[3]];
        img[4].GetComponent<Image>().sprite = stars[lvl[4]];
        img[5].GetComponent<Image>().sprite = stars[lvl[5]];
        img[6].GetComponent<Image>().sprite = stars[lvl[6]];
    }
}
