using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class fashionFreakTool : MonoBehaviour
{
    int intstore;
    string store;
    void Start()
    {
        if(PlayerPrefs.GetInt("eTool", 0) == 3){
            store = "1";
        if(PlayerPrefs.GetInt("skin2", 0) == 1){
            store = store + "2";
        }
        if(PlayerPrefs.GetInt("skin3", 0) == 1){
            store = store + "3";
        }
        if(PlayerPrefs.GetInt("skin4", 0) == 1){
            store = store + "4";
        }
        if(PlayerPrefs.GetInt("skin5", 0) == 1){
            store = store + "5";
        }
        if(PlayerPrefs.GetInt("skin6", 0) == 1){
            store = store + "6";
        }
        if(PlayerPrefs.GetInt("skin7", 0) == 1){
            store = store + "7";
        }
        store = "1234567";
        store = store[UnityEngine.Random.Range(0,store.Length+1)].ToString();
        PlayerPrefs.SetInt("eskin", Convert.ToInt32(store));
        }
    }
}
