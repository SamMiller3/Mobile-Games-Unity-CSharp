using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class calcScore : MonoBehaviour
{

    public Text scoreDisp;
    public static double score;


    // Start is called before the first frame update

    void Start()
    {
        //if the player has the headstart powerup equipped
        //then give them a random headstart 100-500
        //otherwise score starts at 0
        if (PlayerPrefs.GetInt("currentupgrade",0)==1){
            score=UnityEngine.Random.Range(100,500);
        }
        else{
            score=0;
        }
    }

    // FixedUpdate is called fixed number of times regardless of fps

    void FixedUpdate()
    { 
        //check if game is paused

        if (pause.Pause){

        //increase score by time since last frame multiplied by 30
        //so it will run on same time on all computers

        score += 1 * (Time.deltaTime * 30);

        //convert score to int to display on screen

        score = Math.Round(score);

        //display score

        scoreDisp.text = "Score: " + score.ToString();
        }
    }
}
