using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonMove : MonoBehaviour
{
    float scr;
    public Sprite pink;
    public Sprite yellow;
    public Sprite orange;
    private int skin;
    void Start()
    {
        transform.position = new Vector3(transform.position.x,transform.position.y,-1);
        skin = Random.Range(1,4);
        if (skin == 1) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = pink;
        }
        if (skin == 2) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = yellow;
        }
        if (skin == 3) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = orange;
        }
    }


    void Update()
    {  
        if (pause.paused == 0){
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

//(score.Score / 100) * Time.deltaTime