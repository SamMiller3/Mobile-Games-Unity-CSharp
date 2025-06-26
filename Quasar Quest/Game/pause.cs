using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    //public static can be accessed by any class to check if game is paused
    //named Pause so var name and class name don't clash
    public static bool Pause;

    public static int gameOver;


    //on first frame set game to not paused and set game status to not over 
    void Start(){
        Pause=true;
        gameOver=0;
    }

    //when the button is clicked this function will be called
    public void Click(){

        if(Pause){
           Pause = false; 
        }

        else{
            Pause = true;
        }

    }


    //call once per frame
    void Update(){


        //hide if game is in playing state
        if(gameOver!=0){
           gameObject.SetActive(false); 
        }
    }
}
