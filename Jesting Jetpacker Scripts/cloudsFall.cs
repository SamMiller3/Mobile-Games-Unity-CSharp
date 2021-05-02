using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudsFall : MonoBehaviour
{
    public Sprite one;
    public Sprite two;
    public Sprite three;
    private int skin;
    private float scr;
    void Start()
    {
        skin = Random.Range(1,3);
        if (skin == 1) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = one;
        }
        if (skin == 2) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = two;
        }
        if (skin == 3) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = three;
        }
    }
    void FixedUpdate()
    {
         if (pause.paused == 0){
            scr = (float)score.Score;
        if (scr > 1200){
            transform.position = transform.position - new Vector3(0, (1200 / 200) * Time.deltaTime , 0);
        }
        else {
            transform.position = transform.position - new Vector3(0, ((scr+200) / 200) * Time.deltaTime , 0);
        }
        if (transform.position.y < -7.4f){
            Destroy(this.gameObject);
        }
        }
    }
}
