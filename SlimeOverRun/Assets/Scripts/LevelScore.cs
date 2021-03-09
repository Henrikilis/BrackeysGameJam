using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public static int lvl0;
    public static int lvl1;
    public static int lvl2;
    public static int lvl3;
    public static int lvl4;
    public static int lvl5;
    public static int lvl6;

    public static int pb0;
    public static int pb1;
    public static int pb2;
    public static int pb3;
    public static int pb4;
    public static int pb5;
    public static int pb6;

    public Image[] img;

    public Sprite[] stars;

    // Start is called before the first frame update
    void Start()
    {
        pb0 = PlayerPrefs.GetInt("pb0");
        pb1 = PlayerPrefs.GetInt("pb1");
        pb2 = PlayerPrefs.GetInt("pb2");
        pb3 = PlayerPrefs.GetInt("pb3");
        pb4 = PlayerPrefs.GetInt("pb4");
        pb5 = PlayerPrefs.GetInt("pb5");
        pb6 = PlayerPrefs.GetInt("pb6");

        img[0].GetComponent<Image>().sprite = stars[pb0];
        img[1].GetComponent<Image>().sprite = stars[pb1];
        img[2].GetComponent<Image>().sprite = stars[pb2];
        img[3].GetComponent<Image>().sprite = stars[pb3];
        img[4].GetComponent<Image>().sprite = stars[pb4];
        img[5].GetComponent<Image>().sprite = stars[pb5];
        img[6].GetComponent<Image>().sprite = stars[pb6];
    }

    // Update is called once per frame
    void Update()
    {
        //img[0].GetComponent<Image>().sprite = stars[pb0];
        //img[1].GetComponent<Image>().sprite = stars[pb1];
        //img[2].GetComponent<Image>().sprite = stars[pb2];
        //img[3].GetComponent<Image>().sprite = stars[pb3];
        //img[4].GetComponent<Image>().sprite = stars[pb4];
        //img[5].GetComponent<Image>().sprite = stars[pb5];
        //img[6].GetComponent<Image>().sprite = stars[pb6];
    }
}
