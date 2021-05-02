using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    int price;
    public GameObject owned;
    public GameObject baught;
    public GameObject moreCoins;
    void Start(){
        PlayerPrefs.SetInt("skin1", 1);
        owned.SetActive(false);
        baught.SetActive(false);
        moreCoins.SetActive(false);
    }
    IEnumerator More(){
        moreCoins.SetActive(true);
        yield return new WaitForSeconds(1);
        moreCoins.SetActive(false);
    }
    IEnumerator Owned(){
        owned.SetActive(true);
        yield return new WaitForSeconds(1);
        owned.SetActive(false);
    }
    IEnumerator Sucs(){
        baught.SetActive(true);
        yield return new WaitForSeconds(1);
        baught.SetActive(false);
    }
   public void Click(){
       if(skinUI.skin == 1){
           price = 0;
       }
       if(skinUI.skin == 2){
           price = 750;
       }
       if(skinUI.skin == 3){
           price = 1150;
       }
       if(skinUI.skin == 4){
           price = 2200;
       }
       if(skinUI.skin == 5){
           price = 3100;
       }
       if(skinUI.skin == 6){
           price = 3999;
       }
       if(skinUI.skin == 7){
           price = 4700;
       }
       if (PlayerPrefs.GetInt("coins", 0) < price-1){
           StartCoroutine(More());
       }
       else{
           if(skinUI.skin == 1){
               if(PlayerPrefs.GetInt("skin1", 0) != 1){
                   PlayerPrefs.SetInt("skin1", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(skinUI.skin == 2){
               if(PlayerPrefs.GetInt("skin2", 0) != 1){
                   PlayerPrefs.SetInt("skin2", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(skinUI.skin == 3){
               if(PlayerPrefs.GetInt("skin3", 0) != 1){
                   PlayerPrefs.SetInt("skin3", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(skinUI.skin == 4){
               if(PlayerPrefs.GetInt("skin4", 0) != 1){
                   PlayerPrefs.SetInt("skin4", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(skinUI.skin == 5){
               if(PlayerPrefs.GetInt("skin5", 0) != 1){
                   PlayerPrefs.SetInt("skin5", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
       }
   }
}
