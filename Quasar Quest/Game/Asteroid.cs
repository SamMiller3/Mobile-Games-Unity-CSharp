using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Asteroid : MonoBehaviour
{
    public float MODIFIER;

    private endMenuUI endMenuUIInstance; // reference to current instance of endMenuUI

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
                //check if currently equipped is the infinite lives powerup AND random chance of 1 to 10:
                if ((PlayerPrefs.GetInt("currentupgrade",0)==2) && (UnityEngine.Random.Range(1,10)==1))
                {
                    endMenuUIInstance=GameObject.Find("UI").GetComponent<endMenuUI>(); // get access to endMenuUI.cs script
                    endMenuUIInstance.reviveClick(false); // call the revive function in the end menu ui script to revive the player.
                                                        // feed in false so revive function knows revive was 
                }                                       // from infinite lives not being bought
                else{
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
        if(pause.Pause){

            //scroll asteroid accross screen based at rate of (log of current score), 
            //multiplied by Time.fixedDeltaTime to ensure scrolls at fixed rate regardless of FPS
            //multiplied by MODIFIER otherwise it would scroll too slowly even if it is increasing in difficulty at correct rate
            //multiplied by current powerup speed
            transform.position = new Vector3(transform.position.x-(float)(Math.Log(calcScore.score+2,10)+1)
            *Time.fixedDeltaTime*MODIFIER*powerupMove.powerUpSpeed,transform.position.y,0);

            if (transform.position.x<-9.5){
                //if on edge of screen destroy game object self 
                Destroy(gameObject);
            }

        }
    }
}
