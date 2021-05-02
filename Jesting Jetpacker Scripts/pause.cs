using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject resume;
    public GameObject Menu;
    public static int paused;
    void Start()
    {
        paused = 0;
        PauseUI.SetActive(false);
        Menu.SetActive(false);
        resume.SetActive(false);
    }
    void Update(){
        if (colMenu.game != 1){
        PauseUI.SetActive(false);
        Menu.SetActive(false);
        resume.SetActive(false);
        }
        
    }
    public void click()
    {
       paused=1; 
       PauseUI.SetActive(true);
        Menu.SetActive(true);
        resume.SetActive(true);
    }
}
