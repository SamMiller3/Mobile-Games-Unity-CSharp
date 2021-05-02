using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketFall : MonoBehaviour
{
    private float scr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         if (pause.paused == 0){
            scr = (float)score.Score;
        if (scr > 2900){
            transform.position = transform.position - new Vector3(0,((1 + Random.Range(0.1f,0.3f))/((2900+0.001f) * (Time.deltaTime+0.001f))*8),0);
        }
        else {
            transform.position = transform.position - new Vector3(0,((1 + Random.Range(0.1f,0.3f))/((scr+0.001f) * (Time.deltaTime+0.001f)) * 8),0);
        }
        if (transform.position.y < -7.4f){
            Destroy(this.gameObject);
        }
        }
    }
}
