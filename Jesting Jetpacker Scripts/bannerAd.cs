using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class bannerAd : MonoBehaviour
{
    public static int on;
    string gameId = "4026985";
    string placementId = "Banner";
    bool testMode = false;
    void Update(){
        if (on == 1){
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(placementId);
            
        }
        else{
            Advertisement.Banner.Hide();
        }
    }
    void Start()
    {
        on = 1;
        StartCoroutine(showAd());
    }
    IEnumerator showAd(){
        Advertisement.Initialize(gameId, testMode);
        while(!Advertisement.IsReady(placementId)){
            yield return null;
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(placementId);
    }
    
}
