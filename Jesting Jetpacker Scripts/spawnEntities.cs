using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEntities : MonoBehaviour
{
    public GameObject Balloon;
    public GameObject clouds;
    public GameObject Rocket;
    public GameObject booster;
    public GameObject player;
    int rand;
    float scr;
    int i;
    int range;
    private int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        player.gameObject.SetActive(true);
        StartCoroutine(spawnEnt());
        i = 0;
        j=0;
        range = Random.Range(4,6);
    }
    //spawn
    IEnumerator spawnEnt()
    {
        while (1>0) {
            if (pause.paused == 0) {
                //1 / ((scr / 200) * Time.deltaTime + Random.Range(0.4f, 0.6f))
            if (scr > 1200f && scr < 2000f){
                yield return new WaitForSeconds(1 / ((1200 / 200) + Random.Range(0.4f, 0.6f)));
            }
            if (scr < 1200f){
                yield return new WaitForSeconds(1 / (((scr+200) / 200) + Random.Range(0.4f, 0.6f)));
            }
            if (scr >2000f && scr < 3400f){
                yield return new WaitForSeconds((1 / (((scr)  + Random.Range(0.4f, 0.6f)) * Time.deltaTime)) * 12);
            }
            if (scr > 2900f){
                yield return new WaitForSeconds((1 / (((2900)  + Random.Range(0.4f, 0.6f)) * Time.deltaTime) * 12));
            }
            i+=1;
            j+=1;
        if (j == 2 && Random.Range(0,15) == 4){
            j=0;
            Instantiate(booster, new Vector3(Random.Range(-2.3f, 2.3f), 5, -1), Quaternion.Euler(0, 0, -1));
        }
        if (j == 2){
            j=0;
        }
        if (scr < 2000f){
            Instantiate(Balloon, new Vector3(Random.Range(-2.3f, 2.3f), 5, 0), Quaternion.Euler(0, 0, -1));
        }
        if (scr > 2000f){
            Instantiate(Rocket, new Vector3(Random.Range(-2.3f, 2.3f), 5, 0), Quaternion.Euler(0, 0, -1));
        }
        if (i == range){ 
        range = Random.Range(4,6);
        Instantiate(clouds, new Vector3(Random.Range(-2.3f, 2.3f), 5, 0), Quaternion.Euler(0, 0, -1));
        i = 0;
        }        
            }
            if (pause.paused == 1) {
                yield return new WaitForSeconds(0.1f);
            }
            }
    }
    // Update is called once per frame
    void Update()
    {
        scr = (float)score.Score;
        Balloon.transform.position = new Vector3(10, 20, 10);
    }
}
