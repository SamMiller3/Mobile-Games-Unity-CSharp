using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    public GameObject bgUI;
    public GameObject confirm;
    public GameObject cancel;
    public GameObject coins;
    public GameObject desc;
    public Text Desc;
    public Text Coins;
    public static int buy;
    public static int tool;
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
            desc.SetActive(false);
        }
        else{
            bgUI.SetActive(true);
            confirm.SetActive(true);
            cancel.SetActive(true);
            coins.SetActive(true);
            desc.SetActive(true);
        }
        if (tool == 1){
            Coins.text = "750";
            Desc.text = "Head start: Start off with a score of 300!";
        }
        if (tool == 2){
            Coins.text = "3500";
            Desc.text = "Money Money Money!: Earn twice as much money each time.";
        }
        if (tool == 3){
            Coins.text = "1450";
            Desc.text = "Fashion Freak: Enter in a random outfit you own.";
        }
        if (tool == 4){
            Coins.text = "3700";
            Desc.text = "Double Lives: Have a 25% chance each round to be saved by this powerup when you die (only works once per round)";
        }
        if (tool == 5){
            Coins.text = "4200";
            Desc.text = "Intern: Hire an intern to collect all shields for you!";
        }
    }
}
