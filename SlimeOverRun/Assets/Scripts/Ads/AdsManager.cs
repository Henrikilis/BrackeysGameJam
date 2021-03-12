using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Advertisement.Initialize("4046445", true);

        while (!Advertisement.IsReady())
            yield return null;

        Advertisement.Show();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
