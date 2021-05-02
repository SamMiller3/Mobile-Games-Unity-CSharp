using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioOn : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    public static int audio = 0;
    void Update(){
        if(audio == 1){
            this.gameObject.GetComponent<Image>().sprite = off;
        }
        if(audio == 0){
            this.gameObject.GetComponent<Image>().sprite = on;
        }
    }
    // Update is called once per frame
    public void click()
    {
        if(audio == 1){
            audio = 0;
        }
        else{
            audio = 1;
        }
    }
}
