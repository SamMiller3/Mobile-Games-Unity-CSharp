using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public static bool Pause; 
    void Start(){
        Pause = true;
    }
    public void Click(){
        if(Pause){
           Pause = false; 
        }
        else{
            Pause = true;
        }
    }
}
