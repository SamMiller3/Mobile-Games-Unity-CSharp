using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject rsume;
    public GameObject Menu;
    
    public void click()
    {
        pause.paused=0;
        PauseUI.SetActive(false);
        Menu.SetActive(false);
        rsume.SetActive(false);
    }
}
