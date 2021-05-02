using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinUI : MonoBehaviour
{
    public GameObject bgUI;
    public GameObject confirm;
    public GameObject cancel;
    public GameObject coins;
    public Text Coins;
    public static int buy;
    public static int skin;
    void Start()
    {
        buy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (buy == 0){
            bgUI.SetActive(false);
            confirm.SetActive(false);
            cancel.SetActive(false);
            coins.SetActive(false);
        }
        else{
            bgUI.SetActive(true);
            confirm.SetActive(true);
            cancel.SetActive(true);
            coins.SetActive(true);
        }
        if (skin == 1){
            Coins.text = "0";
        }
        if (skin == 2){
            Coins.text = "750";
        }
        if (skin == 3){
            Coins.text = "1150";
        }
        if (skin == 4){
            Coins.text = "2200";
        }
        if (skin == 5){
            Coins.text = "3150";
        }
        if (skin == 6){
            Coins.text = "3999";
        }
        if (skin == 7){
            Coins.text = "4700";
        }
    }
}
