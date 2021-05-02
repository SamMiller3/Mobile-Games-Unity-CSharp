using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class playAdForCoins : MonoBehaviour, IUnityAdsListener
{
    public GameObject notReady;
    public GameObject Up;
    public Text countUp;
    int i;
    public void OnUnityAdsDidStart(string placementId){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsReady(string placementId){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidError(string placementId){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        if (showResult == ShowResult.Finished){
            //PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) + 200));
            StartCoroutine(cUp());
        }
        else{
            StartCoroutine(noAd());
        }
    }
    void Start(){
        Up.SetActive(false);
        notReady.SetActive(false);
    }
    IEnumerator cUp(){
        i=0;
        Up.SetActive(true);
        PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) + 200));
        countUp.text = "You got:";
        while (201>i){
            countUp.text = "You got: " + i.ToString() + "coins";
            i+=1;
            yield return new WaitForSeconds(0.00125f);
        }
        yield return new WaitForSeconds(0.3f);
        Up.SetActive(false);
    }
    string placement = "rewardedVideo";
    IEnumerator noAd(){
        notReady.SetActive(true);
        yield return new WaitForSeconds(1);
        notReady.SetActive(false);
    }
    public void Click(){
        StartCoroutine(showAd());
    }
    IEnumerator showAd(){
        Advertisement.AddListener(this);
        Advertisement.Initialize("4026984", true);
        while (!Advertisement.IsReady(placement)){
            yield return null;
        }
        Advertisement.Show(placement);
    }
}
