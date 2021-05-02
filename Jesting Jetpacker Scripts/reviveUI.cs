using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Advertisements;

public class reviveUI : MonoBehaviour, IUnityAdsListener
{
    public GameObject Revive;
    public GameObject skip;
    public GameObject advert;
    public GameObject coin;
    public GameObject coinsEarned;
    public GameObject calcCoins;
    public Text calcCoin;
    public GameObject Pause;
    public GameObject sky;
    public GameObject camera;
    public GameObject player;
    public GameObject notReady;
    public GameObject MoreCoins;
    string placement = "rewardedVideo";
    public static int coinsInMatch;
    public void OnUnityAdsDidError(string message){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        if (showResult == ShowResult.Finished){
            Rev();
        }
        else{
            StartCoroutine(noAd());
        }
    }
    public void OnUnityAdsDidStart(string placementId){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsReady(string placementId){
        throw new System.NotImplementedException();
    }
    void Start()
    {
        notReady.gameObject.SetActive(false);
        Revive.gameObject.SetActive(false);
        advert.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);
        coin.gameObject.SetActive(false);
        calcCoins.gameObject.SetActive(false);
        coinsEarned.gameObject.SetActive(false);
        MoreCoins.gameObject.SetActive(false);
    }
    void Update()
    {
        if (colMenu.game == 2){
        Revive.gameObject.SetActive(true);
        advert.gameObject.SetActive(true);
        skip.gameObject.SetActive(true);
        coin.gameObject.SetActive(true);
        calcCoins.gameObject.SetActive(false);
        coinsEarned.gameObject.SetActive(false);
        Pause.gameObject.SetActive(false);
        MoreCoins.gameObject.SetActive(false);
        }
        if (colMenu.game == 1){
            Pause.gameObject.SetActive(true);
            Revive.gameObject.SetActive(false);
        advert.gameObject.SetActive(false);
        skip.gameObject.SetActive(false);
        coin.gameObject.SetActive(false);
        calcCoins.gameObject.SetActive(false);
        coinsEarned.gameObject.SetActive(false);
        MoreCoins.gameObject.SetActive(false);
        }
        if(colMenu.game == 3){
            skip.gameObject.SetActive(true);
            calcCoins.gameObject.SetActive(true);
        coinsEarned.gameObject.SetActive(true);
        Revive.gameObject.SetActive(false);
        advert.gameObject.SetActive(false);
        coin.gameObject.SetActive(false);

        }
    }
    IEnumerator noAd(){
        notReady.SetActive(true);
        yield return new WaitForSeconds(1);
        notReady.SetActive(false);
    }
    IEnumerator showAd(){
        Advertisement.AddListener(this);
        Advertisement.Initialize("4026984", true);
        while (!Advertisement.IsReady(placement)){
            yield return null;
        }
        Advertisement.Show(placement);
    }
    void Rev(){
         GameObject[] enemies = GameObject. FindGameObjectsWithTag("balloon");
            for(int i=0; i< enemies. Length; i++)   
            {
            Destroy(enemies[i]);
            }
        GameObject[] enemies2 = GameObject. FindGameObjectsWithTag("rocket");
            for(int i=0; i< enemies2. Length; i++)   
            {
            Destroy(enemies2[i]);
            }
        player.SetActive(true);
        camera.transform.position = new Vector3(0,0,-10);
        sky.transform.position = new Vector3(0,0,1);
        player.transform.position = new Vector3(0, -3, -1);
        player.transform.rotation = Quaternion.Euler(0,0,0);
        colMenu.go = 1;
        colMenu.game = 1;
        pause.paused = 0;
    }
    public void advertRevive(){
            StartCoroutine(showAd());
    }
    public void coinsRevive(){
        if (PlayerPrefs.GetInt("coins", 0) > 250){
            PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - 250));
            GameObject[] enemies = GameObject. FindGameObjectsWithTag("balloon");
            for(int i=0; i< enemies. Length; i++)   
            {
            Destroy(enemies[i]);
            }
        GameObject[] enemies2 = GameObject. FindGameObjectsWithTag("rocket");
            for(int i=0; i< enemies2. Length; i++)   
            {
            Destroy(enemies2[i]);
            }
        player.SetActive(true);
        camera.transform.position = new Vector3(0,0,-10);
        sky.transform.position = new Vector3(0,0,1);
        player.transform.position = new Vector3(0, -3, -1);
        player.transform.rotation = Quaternion.Euler(0,0,0);
        colMenu.go = 1;
        colMenu.game = 1;
        pause.paused = 0;
        }
    }
    void displayCalc(){
        //calccoins
        //if (scr > 500){
        // scr / 10
        //}
        //else{
            //calcCoin.text = 0;
        //}
        if (score.Score > 500){
             if(PlayerPrefs.GetInt("eTool", 0) != 2){
          calcCoin.text = "Coins: " + Math.Round((score.Score / 60) *1).ToString();
             }
             else{
                 calcCoin.text = "Coins: " + Math.Round((score.Score / 60) *2).ToString();
                 MoreCoins.gameObject.SetActive(true);
             }
          coinsInMatch = (int)Math.Round((score.Score / 60) *1);
          PlayerPrefs.SetInt("coins", (int)PlayerPrefs.GetInt("coins", 0)+coinsInMatch);
        }
        else{
            calcCoin.text = "Coins: " + 0.ToString();
        }
    }
    public void Skip(){
        if (colMenu.game == 3){
            colMenu.game = 1;
            if(PlayerPrefs.GetInt("mission", 1) == 5){
                if(score.Score > PlayerPrefs.GetInt("misInt", 1)){
                    PlayerPrefs.SetInt("compIntx", PlayerPrefs.GetInt("compIntx", 0)+1);
                }
            }
            if(PlayerPrefs.GetInt("mission", 1) == 7){
                    PlayerPrefs.SetInt("compIntx", PlayerPrefs.GetInt("compIntx", 0)+1);
            }
            SceneManager.LoadScene("Menu");
        }
        if (colMenu.game == 2){
            colMenu.game+=1;
            displayCalc();
        }
    }
}
