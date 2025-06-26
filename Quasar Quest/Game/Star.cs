using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    private float size;

    // Start is called before the first frame update
    void Start()
    {

        //set size of star to size
        size=Random.Range(0.08f,0.3f);
        transform.localScale = new Vector3(size,size,1);
    }

    // FixedUpdate is called fixed number of times regardless of fps
    void FixedUpdate()
    {

        //check if game is paused
        if(pause.Pause){

        //scroll across screen
        transform.position=new Vector3(transform.position.x-(0.9f*Time.fixedDeltaTime),transform.position.y,1);

        if (transform.position.x<-9.5){

			//if on edge of screen destroy game object self 

			Destroy(gameObject);
        }

        }
    }
}
