using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasFall : MonoBehaviour
{
    public Sprite Red;
    public Sprite Orange;
    public Sprite Yellow;
    private int skin;
    float size;
    void Start()
    {
        size = Random.Range(0.70f,1.30f);
        transform.localScale = new Vector3(size,size,0);
        skin = Random.Range(1,3);
        if (skin == 1) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Red;
        }
        if (skin == 2) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Orange;
        }
        if (skin == 3) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Yellow;
        }
    }
    void FixedUpdate()
    {
        if (pause.paused == 0){
            transform.position = transform.position + new Vector3(0, -1.75f * Time.deltaTime, 0);
        if (transform.position.y < -7){
            Destroy(this.gameObject);
        }
        }
    }
 }

