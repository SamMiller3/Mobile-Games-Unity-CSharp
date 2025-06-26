using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //import scene managment library to load different scenes
using UnityEngine.UI; //to control texture

public class menuButtons : MonoBehaviour
{
    //main button gameobjects
    public GameObject Play; 
    public GameObject Shop;
    public GameObject Equip;
    public GameObject missions;
    //second menu gameobjects (all child of this gameobject)
    public GameObject menuTwo;
    //purchaseMenu for skins
    public GameObject skinsPurchBg;
    //equipMenu for skins
    public GameObject skinsEquBg;
    
    //display ship:
    public GameObject displayShip; //reference display ship gameobject
    private RawImage shipRawImage; // Reference to the ship's Raw Image
    public Texture2D[] shipTextures; // Array of ship Textures (will add the sprites in unity inspector editor)
    
    //current menu mode
    public static int menuMode;
    

    public int rotationSpeed = 10; //rotation speed of ship

    // Start is called before the first frame update
    void Start()
    {
        //set menu mode to 1 (main menu)
        menuMode=1;
    }

    // Update is called once per frame
    void Update()
    {
        //if main menu
        if (menuMode==1){
            //show main menu (play,shop,equip), missions
            Play.SetActive(true); 
            Shop.SetActive(true);
            Equip.SetActive(true);
            missions.SetActive(true);

            //hide second menu buttons
            menuTwo.SetActive(false);

            //show display ship
            displayShip.SetActive(true);
            //constantly rotate ship parallel to z axis
            displayShip.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); 

            //display correct ship skin
            shipRawImage = displayShip.GetComponent<RawImage>(); // get the Raw Image component from the display ship GameObject
            int currentSkinIndex = PlayerPrefs.GetInt("currentSkin", 0); // set playerpref to an int so it can be used in script, 
                                                                            //default to 0 if not set
            shipRawImage.texture = shipTextures[currentSkinIndex]; // set current sprite to current index in ship sprites

        }
        //if second menu (equip or shop)
        else if (menuMode==2 || menuMode==3){
            //hide main menu (play,shop,equip), missions
            Play.SetActive(false); 
            Shop.SetActive(false);
            Equip.SetActive(false);
            missions.SetActive(false);

            //show second menu buttons
            menuTwo.SetActive(true);

            //hide display ship
            displayShip.SetActive(false);
        }
        //if skin menu (equip skin or shop for skins) or upgrades menu (shop/equip upgrades)
        else if (menuMode==5 || menuMode==7 || menuMode==4 || menuMode==6){
            //hide main menu (play,shop,equip), missions
            Play.SetActive(false); 
            Shop.SetActive(false);
            Equip.SetActive(false);
            missions.SetActive(false);

            //hide second menu buttons
            menuTwo.SetActive(false);

            //hide display ship
            displayShip.SetActive(false);
        }
    }

    //on play button click load scene "Game"
    public void startGame(){
        SceneManager.LoadScene("Game");
    }

    //on Shop button click load menuMode 2
    public void shopButtonClick(){
        menuMode=2;
    }

    //on equip button click load menuMode 3
    public void equipButtonClick(){
        menuMode=3;
    }

    //on home button click load menuMode 1
    public void mainMenuButton(){
        menuMode=1;
    }

    //skins button click
    public void skinsButtonClick(){
        skinsPurchBg.SetActive(false); // hide skin purchase menu
        skinsEquBg.SetActive(false); // hide skin equ menu
        //if in shop (menuMode=2) switch to shop for skins (menuMode=5)
        if (menuMode==2){
            menuMode=5;
        }
        //if in equip (menuMode=3) switch to equip for skins (menuMode=7)
        if (menuMode==3){
            menuMode=7;
        }
    }

    //upgrades button click
    public void upgradesButtonClick(){
        //if in shop (menuMode=2) switch to shop for upgrades (menuMode=4)
        if (menuMode==2){
            menuMode=4;
        }
        //if in equip (menuMode=3) switch to equip for upgrades (menuMode=6)
        if (menuMode==3){
            menuMode=6;
        }
    }

}
