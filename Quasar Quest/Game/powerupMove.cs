using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class powerupMove : MonoBehaviour
{
    public static int powerUpSpeed; //store if powerup currently in use, public static so can access from any gameobject 
    public float rotationSpeed = 10f; // Speed of rotation

    void Start(){
        //at beginning of game set powerup in use to 1
        powerUpSpeed=1;

    }

    //called fixed number of times regardless of FPS
    void FixedUpdate()
    {
        
        //if game is NOT paused scroll powerup accross screen from right to left proportional to 1/log(score) speed
        if(pause.Pause){

        transform.position = new Vector3(transform.position.x-(float)(Math.Log(calcScore.score+2,10)+1)*Time.fixedDeltaTime*1.5f,transform.position.y,0);
        
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);  // Rotate around the y-axis

        }

		    if (transform.position.x<-9.5){
			    //if on edge of screen destroy game object self 
			    Destroy(gameObject);
            }

    }


    //on colliding with another gameobject

    private void OnTriggerEnter2D(Collider2D other) {

        //if it is the player

        if (other.gameObject.CompareTag("Player")) {
            //add 1 to powerups collected this round:
            game.powerUpsCollected+=1;

            //start using powerup, set powerup speed to 4
            powerUpSpeed=4;

            //if the current upgrade equipped is the better powerups upgrade
            //add 1000 to the score, otherwise add 500

            if (PlayerPrefs.GetInt("currentupgrade",0)==3){
                calcScore.score+=1000; //add 1000 to score
            }
            else{
                calcScore.score+=500; //add 500 to score
            }

            transform.position = new Vector3(50, 50, 0); //go off screen so power up dissapears
                                                        //(cannot delete powerup yet as has to run functionality)
            
            StartCoroutine(usePowerUp()); //wait 1.5 seconds
        }

    }
    IEnumerator usePowerUp(){
        yield return new WaitForSeconds(2);
        powerUpSpeed=1; //power up no longer in use
        Destroy(gameObject); //delete current instance of powerup
    }
}
