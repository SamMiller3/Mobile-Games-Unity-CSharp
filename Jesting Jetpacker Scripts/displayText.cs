using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayText : MonoBehaviour
{
    public Text scre;
    public Text highscore;
    public Text coins;

    
    void Update()
    {
        //set highscore:
        if (score.Score > PlayerPrefs.GetInt("highscore", 0)){
            PlayerPrefs.SetInt("highscore", (int)score.Score);
        }
        scre.text = "SCORE: " + score.Score.ToString();
        highscore.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore", 0).ToString();
        coins.text = "Coins: " + PlayerPrefs.GetInt("coins", 0).ToString();
    }
}
