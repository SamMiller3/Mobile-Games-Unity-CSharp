using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    public void Click(){
        PlayerPrefs.SetInt("gamesPlayed", PlayerPrefs.GetInt("gamesPlayed", 0)+1);
        SceneManager.LoadScene("Game");
    }
}
