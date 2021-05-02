using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuBalloon : MonoBehaviour
{
    float scr;
    public Sprite pink;
    public Sprite yellow;
    public Sprite orange;
    private int skin;
    private float speed;
    void Start()
    {
        speed = Random.Range(0.9f,1.6f);
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
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime,0);
        if (transform.position.y > 7.4f){
            Destroy(this.gameObject);
        }
    }
}
