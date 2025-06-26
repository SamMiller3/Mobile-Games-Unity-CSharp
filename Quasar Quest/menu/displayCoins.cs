//libraries:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;


public class displayCoins : MonoBehaviour
{
    public GameObject coinIcon; //as the coin text gameobject is nested under the coin icon gameobject
    //I only need to access coin icon, hiding this will hide both and showing this will show both.

    public TextMeshProUGUI coinText;

    void Update()
    {

        //check which scene is currently loaded:

        if (SceneManager.GetSceneByName("Game").isLoaded){
        
        //if game scene is loaded then need to check which game state.
        //if game in playing state do not show coins, if in any other state show coins
        if (pause.gameOver!=0){
            coinIcon.SetActive(true);

            //update coins display text to current value of coins
            coinText.text= PlayerPrefs.GetInt("coins", 0).ToString();
        }
        if (pause.gameOver==0){

            coinIcon.SetActive(false);

        }


        }
        else{
            //if any other scene is loaded then always just show coins
            coinIcon.SetActive(true);
            coinText.text= PlayerPrefs.GetInt("coins", 0).ToString();
            
        }
    }
}
