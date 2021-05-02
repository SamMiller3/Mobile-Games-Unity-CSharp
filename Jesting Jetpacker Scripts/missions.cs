using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class missions : MonoBehaviour
{
    public GameObject claim;
    public GameObject na;
    public Text display;
    public Text coinsEd;
    public GameObject coinsE;
    int coins;
    void Start(){
        coinsE.SetActive(false);
    }
    IEnumerator showCoins(){
        coinsE.SetActive(true);
        coinsEd.text = "REWARD: " + coins + " COINS";
        yield return new WaitForSeconds(1);
        coinsE.SetActive(false);
    }
    public void Click(){
        coins = Random.Range(1,4);
        if (coins == 1){
            coins = 15;
        }
        if (coins == 2){
            coins = 30;
        }
        if (coins == 3){
            coins = 45;
        }
        if (coins == 1){
            coins = 0;
        }
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)+coins);
        StartCoroutine(showCoins());
        PlayerPrefs.SetInt("completed", 0);
        PlayerPrefs.SetInt("mission", Random.Range(2,8));
        if(PlayerPrefs.GetInt("mission", 1) == 2){
            PlayerPrefs.SetInt("misInt", Random.Range(4,8));
            PlayerPrefs.SetInt("misInt", PlayerPrefs.GetInt("misInt", 1) * 100);
        }
        if(PlayerPrefs.GetInt("mission", 1) == 3){
            PlayerPrefs.SetInt("misInt", Random.Range(18,30));
        }
        if(PlayerPrefs.GetInt("mission", 1) == 4){
            PlayerPrefs.SetInt("misInt", Random.Range(4,23));
            PlayerPrefs.SetInt("misInt", PlayerPrefs.GetInt("misInt", 1) * 100);
        }
        if(PlayerPrefs.GetInt("mission", 1) == 5){
            PlayerPrefs.SetInt("misIntx", 0);
            PlayerPrefs.SetInt("misIntx", Random.Range(2,4));
            PlayerPrefs.SetInt("misInt", Random.Range(4,23));
            PlayerPrefs.SetInt("misInt", PlayerPrefs.GetInt("misInt", 1) * 100);
        }
        if(PlayerPrefs.GetInt("mission", 1) == 6){
            PlayerPrefs.SetInt("misIntx", 0);
            PlayerPrefs.SetInt("misInt", Random.Range(3,25));
        }
        if(PlayerPrefs.GetInt("mission", 1) == 7){
            PlayerPrefs.SetInt("misIntx", 0);
            PlayerPrefs.SetInt("misIntx", Random.Range(1,3));
        }
        
    }
    void Update()
    {
        
           if(PlayerPrefs.GetInt("completed", 1) == 1){
                na.SetActive(false);
                claim.SetActive(true);
           }
           else{
               na.SetActive(true);
               claim.SetActive(false);
           }
        if(PlayerPrefs.GetInt("mission", 1) == 1){
            display.text = "get a score over 300";
            if (score.Score > 300){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
        if(PlayerPrefs.GetInt("mission", 1) == 2){
            display.text = "score between " + PlayerPrefs.GetInt("misInt", 1).ToString() + " and " + (PlayerPrefs.GetInt("misInt", 1)+50).ToString();
            if (score.Score > PlayerPrefs.GetInt("misInt", 1) && score.Score < (PlayerPrefs.GetInt("misInt", 1)+50)){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
        if(PlayerPrefs.GetInt("mission", 1) == 3){
            display.text = "earn over " + PlayerPrefs.GetInt("misInt", 1).ToString() + " coins in 1 game";
            if (reviveUI.coinsInMatch > PlayerPrefs.GetInt("misInt", 1)){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
        if(PlayerPrefs.GetInt("mission", 1) == 4){
            display.text = "score over " + PlayerPrefs.GetInt("misInt", 1).ToString();
            if (score.Score > PlayerPrefs.GetInt("misInt", 1)){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
        if(PlayerPrefs.GetInt("mission", 1) == 5){
            display.text = "score over " + PlayerPrefs.GetInt("misInt", 1).ToString() + " " + PlayerPrefs.GetInt("misIntx", Random.Range(2,4)).ToString() + " times";
            if (PlayerPrefs.GetInt("compIntx", 1) >= PlayerPrefs.GetInt("misIntx", 0)){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
        if(PlayerPrefs.GetInt("mission", 1) == 6){
            display.text = "earn exactly " + PlayerPrefs.GetInt("misInt", 1).ToString() + " coins in 1 game";
            if (reviveUI.coinsInMatch == PlayerPrefs.GetInt("misInt", 1)){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
        if(PlayerPrefs.GetInt("mission", 1) == 7){
            display.text = "play " + PlayerPrefs.GetInt("misIntx", 1).ToString() + " game(s)";
            if ( PlayerPrefs.GetInt("compIntx", 1) >= PlayerPrefs.GetInt("misIntx", 0)){
                PlayerPrefs.SetInt("completed", 1);
            }
        }
    }
}

