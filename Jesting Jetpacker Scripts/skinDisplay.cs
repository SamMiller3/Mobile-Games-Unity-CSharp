using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinDisplay : MonoBehaviour
{
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite six;
    public Sprite seven;
    void Update()
    {
        if(PlayerPrefs.GetInt("eskin", 0) == 1){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = one;
        }
        if(PlayerPrefs.GetInt("eskin", 0) == 2){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = two;
        }
        if(PlayerPrefs.GetInt("eskin", 0) == 3){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = three;
        }
        if(PlayerPrefs.GetInt("eskin", 0) == 4){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = four;
        }
        if(PlayerPrefs.GetInt("eskin", 0) == 5){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = five;
        }
        if(PlayerPrefs.GetInt("eskin", 0) == 6){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = six;
        }
        if(PlayerPrefs.GetInt("eskin", 0) == 7){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = seven;
        }
    }
}
