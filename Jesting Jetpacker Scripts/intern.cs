using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intern : MonoBehaviour
{
    public GameObject player;
    public GameObject inte;
    
    void Start()
    {
        inte.SetActive(false);
        if(PlayerPrefs.GetInt("eTool", 0) == 5){
            this.gameObject.SetActive(true);
        }
        else{
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 3, -1);
    }
}
