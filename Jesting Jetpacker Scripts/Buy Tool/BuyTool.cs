using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTool : MonoBehaviour
{
    int price;
    public GameObject owned;
    public GameObject baught;
    public GameObject moreCoins;
    void Start(){

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
       if(BuyUI.tool == 1){
           price = 750;
       }
       if(BuyUI.tool == 2){
           price = 3500;
       }
       if(BuyUI.tool == 3){
           price = 1450;
       }
       if(BuyUI.tool == 4){
           price = 3700;
       }
       if(BuyUI.tool == 5){
           price = 4200;
       }
       if (PlayerPrefs.GetInt("coins", 0) < price-1){
           StartCoroutine(More());
       }
       else{
           if(BuyUI.tool == 1){
               if(PlayerPrefs.GetInt("tool1", 0) != 1){
                   PlayerPrefs.SetInt("tool1", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(BuyUI.tool == 2){
               if(PlayerPrefs.GetInt("tool2", 0) != 1){
                   PlayerPrefs.SetInt("tool2", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(BuyUI.tool == 3){
               if(PlayerPrefs.GetInt("tool3", 0) != 1){
                   PlayerPrefs.SetInt("tool3", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(BuyUI.tool == 4){
               if(PlayerPrefs.GetInt("tool4", 0) != 1){
                   PlayerPrefs.SetInt("tool4", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
           if(BuyUI.tool == 5){
               if(PlayerPrefs.GetInt("tool5", 0) != 1){
                   PlayerPrefs.SetInt("tool5", 1);
                   PlayerPrefs.SetInt("coins", (PlayerPrefs.GetInt("coins", 0) - (int)price));
                   StartCoroutine(Sucs());
               }else{
                   StartCoroutine(Owned());
               }
           }
       }
   }
}
