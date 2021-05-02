using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsButton : MonoBehaviour
{
    public GameObject playButton;
    public GameObject ballButton;
    public GameObject StatsButton;
    public GameObject swipeSelect;
    public Material skin1;
    public Material skin2;
    public Material skin3;
    public Material skin4;
    public GameObject ball;
    public GameObject back;
    public static bool sel;
    int move;
    float firstTouch;
    float lastTouch;
    void Start(){
        pause.Pause = true;
        move = 0;
        sel = true;
        swipeSelect.SetActive(false);
        ball.SetActive(false);
        back.SetActive(false);
    }
    public void backClick(){
        sel = true;
        swipeSelect.SetActive(false);
        ball.SetActive(false);
        back.SetActive(false);
        playButton.SetActive(true);
        ballButton.SetActive(true);
        StatsButton.SetActive(true);
    }
    public void Click()
    {
         GameObject[] cars = GameObject. FindGameObjectsWithTag("car");
            for(int i=0; i< cars. Length; i++)   
            {
            Destroy(cars[i]);
            }
        GameObject[] trucks = GameObject. FindGameObjectsWithTag("truck");
            for(int i=0; i< trucks. Length; i++)   
            {
            Destroy(trucks[i]);
            }
        swipeSelect.SetActive(true);
        ball.SetActive(true);
        sel = false;
        back.SetActive(true);
        playButton.SetActive(false);
        ballButton.SetActive(false);
        StatsButton.SetActive(false);
    }

    void Update()
    {
       if (sel == false){
        if(PlayerPrefs.GetInt("skin", 1) >= 5){
            PlayerPrefs.SetInt("skin", 1);
        }
        if(PlayerPrefs.GetInt("skin", 1) <= 0){
            PlayerPrefs.SetInt("skin", 4);
        }
        if(PlayerPrefs.GetInt("skin", 1) == 1){
            ball.gameObject.GetComponent<MeshRenderer>().material = skin1;
        }
        if(PlayerPrefs.GetInt("skin", 1) == 2){
            ball.gameObject.GetComponent<MeshRenderer>().material = skin2;
        }
        if(PlayerPrefs.GetInt("skin", 1) == 3){
            ball.gameObject.GetComponent<MeshRenderer>().material = skin3;
        }
        if(PlayerPrefs.GetInt("skin", 1) == 4){
            ball.gameObject.GetComponent<MeshRenderer>().material = skin4;
        }
           if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch (0);
               if(move == 0){
                   firstTouch = touch.position.x;
               }
               move++; 
               lastTouch = touch.position.x;

        } 
        if(move != 0 && Input.touchCount == 0){
            move = 0;
            if(lastTouch > firstTouch){
                PlayerPrefs.SetInt("skin", PlayerPrefs.GetInt("skin", 1)+1);
            }
            if(lastTouch < firstTouch){
                PlayerPrefs.SetInt("skin", PlayerPrefs.GetInt("skin", 1)-1);
            }
        }
       } 
    }
}
