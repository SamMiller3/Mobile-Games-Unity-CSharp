using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statsButton : MonoBehaviour
{
    public GameObject playButton;
    public GameObject ballsButton;
    public GameObject StatsButton;
    public GameObject Stats;
    public Text stats;
    public GameObject back;
    void Start()
    {
        playButton.SetActive(true);
        ballsButton.SetActive(true);
        StatsButton.SetActive(true);
        Stats.SetActive(false);
        back.SetActive(false);
    }
    public void statClick(){
        back.SetActive(true);
        playButton.SetActive(false);
        ballsButton.SetActive(false);
        StatsButton.SetActive(false);
        Stats.SetActive(true);
        stats.text = "STATS:\nHighscore: " + PlayerPrefs.GetInt("highScore", 0).ToString() + "\nYour average score: " + PlayerPrefs.GetInt("averageScore", 0).ToString() + "\nGames Played: " + PlayerPrefs.GetInt("gamesPlayed", 0).ToString() + "\nCars Bounced: " + PlayerPrefs.GetInt("carsBounced", 0).ToString() + "\nTrucks Bounced: " + PlayerPrefs.GetInt("trucksBounced", 0).ToString() + "\nPetrol Collected: " + PlayerPrefs.GetInt("PetrolCollected", 0).ToString();
    }
    public void Return(){
        playButton.SetActive(true);
        ballsButton.SetActive(true);
        StatsButton.SetActive(true);
        Stats.SetActive(false);
        back.SetActive(false);
    }

}
