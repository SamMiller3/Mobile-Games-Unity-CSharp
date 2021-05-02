using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public static int Score;
    public GameObject newHighscore;
    public Text scr;
    int beaten;
    int averageBeaten;
    public Text highScore;
    public Text average;
    public GameObject overAverage;
    void Start(){
        newHighscore.SetActive(false);
        overAverage.SetActive(false);
        beaten = 0;
        averageBeaten = 0;
        Score = 0;
    }
    IEnumerator popupAver(){
        overAverage.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                average.color = new Color(0.2660086f, 0.7169812f, 0.0473478f, i);
                yield return null;
            }
            overAverage.SetActive(false);
    }
    IEnumerator popup(){
        yield return new WaitForSeconds(0.1f);
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                highScore.color = new Color(0.2660086f, 0.7169812f, 0.0473478f, i);
                yield return null;
            }
            newHighscore.SetActive(false);
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("averageScore", 0) < Score && averageBeaten == 0){
            averageBeaten = 1;
            StartCoroutine(popupAver());
        }
        if (PlayerPrefs.GetInt("highScore", 0) < Score){
            if (beaten == 0){
                newHighscore.SetActive(true);
                StartCoroutine(popup());
            }
            beaten = 1;
            PlayerPrefs.SetInt("highScore", Score);
        }
        scr.text = Score.ToString();
    }
}
