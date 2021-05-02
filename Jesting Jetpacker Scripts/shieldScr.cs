using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldScr : MonoBehaviour
{
    private int i;
    void Start()
    {
        StartCoroutine(end());
    }
    IEnumerator end(){
        i = 0;
        while (i<30){
        if(pause.paused == 0){
        i++;
        yield return new WaitForSeconds(0.1f);
        }
        else{
            yield return null;
        }
        }
        Destroy(this.gameObject);
    }
}
