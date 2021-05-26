using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    //string gameId = "3351412";
    string gameId = "4046445";
    string placementId = "banner";
    bool testMode = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        Advertisement.Initialize(gameId, testMode);

        while (!Advertisement.IsReady(placementId))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }

    // Update is called once per frame
    public void Hide()
    {
        Advertisement.Banner.Hide();
    }
}
