using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayCoins : MonoBehaviour
{
    public Text coins;
    void Update()
    {
        coins.text = "Coins: " + PlayerPrefs.GetInt("coins", 0);
    }
}
