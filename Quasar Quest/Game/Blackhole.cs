using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Blackhole : MonoBehaviour
{
    public float MODIFIER;

    public GameObject player; // reference to player to access the endMenuUI.cs script
    private endMenuUI endMenuUIInstance; // reference to current instance of endMenuUI
    public static bool hitByBlackhole; //public static variable so can be accessed by any script

    void Start(){
        //on first frame set hit by blackhole to false as the player wont have been yet
        hitByBlackhole=false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Check if the other GameObject is tagged with "Player"
        if (other.gameObject.CompareTag("Player")) 
        {
            // Get the Z position of the other GameObject
            float otherZ = other.transform.position.z;

            // Check if the Z is 0 (powerup is not in use)
            if (otherZ == 0f) 
            {
                hitByBlackhole=true; // set player to having been hit by a blackhole

                //check if currently equipped is the infinite lives powerup AND random chance of 1 to 10:
                if ((PlayerPrefs.GetInt("currentupgrade",0)==2) && (UnityEngine.Random.Range(1,10)==1))
                {
                    endMenuUIInstance=GameObject.Find("UI").GetComponent<endMenuUI>(); // get access to endMenuUI.cs script
                    endMenuUIInstance.reviveClick(false); // call the revive function in the end menu ui script to revive the player. 
                }                                       //feed in false so 
                else{                                   //// revive function knows revive was from infinite lives not being bought
                    //if not change game status to over and pause the game
                    pause.gameOver = 1;
                    pause.Pause = false;    

                }
            }
        }
    }


    //called fixed number of times regardless of FPS
    void FixedUpdate()
    {

        //check if game is paused
        if (pause.Pause){

            //scroll blackhole accross screen based at rate of (log of current score), multiplied by Time.fixedDeltaTime 
            //to ensure scrolls at fixed rate regardless of FPS
            //multiplied by MODIFIER otherwise it would scroll too slowly even if it is increasing in difficulty at correct rate
            //multiplied by current powerup speed
            transform.position = new Vector3(transform.position.x-(float)((Math.Log(calcScore.score+2,4))
            *Time.fixedDeltaTime*MODIFIER*powerupMove.powerUpSpeed),transform.position.y,0);

		    if (transform.position.x<-9.5){
			    //if on edge of screen destroy game object self 
			    Destroy(gameObject);
            }

        }

    }
}