using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class colMenu : MonoBehaviour
{
    public Text time;
    public GameObject shield;
    private float i;
    public static int game;
    public static int go;
    public static int shie;
    public GameObject lvs;
    public AudioClip RIP;
    AudioSource audioSource;
    public static int recieve = 0;
    int Dlives;
    public Collider2D collid;
    public GameObject INTERN;
    void Start(){
        collid = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        lvs.SetActive(false);
        Dlives =0;
        shie = 0;
        go=0;
        game = 1;
        time.gameObject.SetActive(false);
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "speedUp" && collision.gameObject.tag != "shield")
        {
             if (shie == 0){
            if(UnityEngine.Random.Range(1,5) == 2 && Dlives == 0 && PlayerPrefs.GetInt("eTool", 0) == 3){
                Dlives = 1;
                StartCoroutine(doubleLives());
                Revive();
            }
            else{
            if(audioOn.audio == 0){
                audioSource.PlayOneShot(RIP);
            }
            StartCoroutine(endGame());
             pause.paused = 1;
             go=2;
            }
             }
        }
        if (collision.gameObject.tag == "speedUp")
        {
            shie = 1;
            Instantiate(shield, new Vector3(0,0,0), Quaternion.Euler(0, 0, -1));
            Destroy(collision.gameObject);
            i=3;
            StartCoroutine(fixBug());
            StartCoroutine(countdown());
        }
    }
    IEnumerator doubleLives(){
        lvs.SetActive(true);
        yield return new WaitForSeconds(1);
        lvs.SetActive(false);
    }
    void Revive(){
         GameObject[] enemies = GameObject. FindGameObjectsWithTag("balloon");
            for(int i=0; i< enemies. Length; i++)   
            {
            Destroy(enemies[i]);
            }
        GameObject[] enemies2 = GameObject. FindGameObjectsWithTag("rocket");
            for(int i=0; i< enemies2. Length; i++)   
            {
            Destroy(enemies2[i]);
            }
        colMenu.go = 1;
        colMenu.game = 1;
        pause.paused = 0;
    }
    IEnumerator fixBug(){
        yield return new WaitForSeconds(3.001f);
        shie = 0;
    }
    IEnumerator countdown(){
        time.gameObject.SetActive(true);
        while (i!=0){
        if(pause.paused==0){
            i-=0.1f;
        i =  (float)Math.Round(i, 2);
        yield return new WaitForSeconds(0.1f);
        time.text = "Time Left: " + i.ToString();
        }
        else{
            yield return null;
        }
        }
        time.gameObject.SetActive(false);
    }
    void Update(){
        if(shie == 0){
            collid.enabled = true;
        }
        if(shie == 1){
            collid.enabled = false;
        }
        else
        if(recieve == 1){
            recieve = 0;
            StartCoroutine(intern());
            shie = 1;
            Instantiate(shield, new Vector3(0,0,0), Quaternion.Euler(0, 0, -1));
            i=3;
            StartCoroutine(fixBug());
            StartCoroutine(countdown());
        }
        GameObject.FindWithTag("shield").transform.position = new Vector3( transform.position.x, -3.56f, 0);
    }
    IEnumerator intern(){
        INTERN.SetActive(true);
        yield return new WaitForSeconds(1);
        INTERN.SetActive(false);
    }
    IEnumerator endGame(){
        yield return new WaitForSeconds(1f);
        go=1;
        game=2;
        this.gameObject.SetActive(false);
    }
}
