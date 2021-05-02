using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class score : MonoBehaviour
{
    public static double Score;
    public Text sco;
    public GameObject headstart;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("eTool", 0) != 1){
            Score = 0;
            headstart.SetActive(false);
        }else{
            Score = 300;
            StartCoroutine(headStart());
        }
    }
    IEnumerator headStart(){
        headstart.SetActive(true);
        yield return new WaitForSeconds(1);
        headstart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pause.paused == 0){
            Score += 1 * (Time.deltaTime * 60);
        Score = Math.Round(Score);
        sco.text = "Score: " + Score.ToString();
        }
    }
}
