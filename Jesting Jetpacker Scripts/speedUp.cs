using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUp : MonoBehaviour
{
    private float scr;
    void Update(){
     if (pause.paused == 0){
         if(colMenu.shie == 0 &&  PlayerPrefs.GetInt("eTool", 0) == 5){
            colMenu.recieve = 1;
            Destroy(this.gameObject);
        }
            scr = (float)score.Score;
        if (scr > 1200){
            transform.position = transform.position - new Vector3(0, (1200 / 100) * Time.deltaTime , 0);
        }
        else {
            transform.position = transform.position - new Vector3(0, ((scr+200) / 100) * Time.deltaTime , 0);
        }
        if (transform.position.y < -7.4f){
            Destroy(this.gameObject);
        }
        }
    }
}
