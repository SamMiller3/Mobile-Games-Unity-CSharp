using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //import textmesh pro library

public class manageupgrades : MonoBehaviour
{
    //upgrades container (all upgrades and scrollbar are children of this gameobject
    //so will be set active if the gameobject is active, hide if gameobject is hidden)
    public GameObject upgrades;


    public Scrollbar scrollbar; // Reference to the scrollbar
    public RectTransform upgradesContainer; // Reference to the RectTransform of the container holding the upgrades game objects
    private float scrollHeight = -400f; // Height over which the objects should scroll (negative as it will be scrolling DOWN)

    public GameObject upgradesPurchBg; //purchaseMenu for upgrades
    public TextMeshProUGUI upgradePurchDesc; // reference to product description
    private int upgradeView = 0; // current upgrade being viewed

    public GameObject upgradesEquBg; //purchaseMenu for upgrades
    public TextMeshProUGUI upgradeEquDesc; // reference to description of upgrade to equip

    public TextMeshProUGUI equipText; // Reference text which will show up when you attempt to equip a upgrade
    public TextMeshProUGUI purchaseText; // Reference text which will show up when you purchase a upgrade

    private float initialPositionY;



    // Update is called once per frame
    void Update()
    {
        //if on menu mode 5 or 7 (shop/equip upgrades) show upgrades container
        if (menuButtons.menuMode==4||menuButtons.menuMode==6){
            upgrades.SetActive(true);
        }
        //otherwise hide
        else{
            upgrades.SetActive(false);
        }


        // Calculate the new Y position for the content container based on the scrollbar value.
        // Mathf.Lerp linearly interpolates between the initial Y position and the target Y position (initialPositionY - scrollHeight).
        // The interpolation factor is determined by the scrollbar value (0.0 to 1.0).
        float newY = Mathf.Lerp(initialPositionY, initialPositionY - scrollHeight, scrollbar.value);

        // Update the anchored position of the content container with the new Y position.
        // The X position remains unchanged.
        upgradesContainer.anchoredPosition = new Vector2(upgradesContainer.anchoredPosition.x, newY);

    }


    //when first upgrade is chosen (headstart)
    public void upgradeOneClick(){
        
        upgradeView=1; //current viewing 1st upgrade

        if (menuButtons.menuMode==4){
            upgradesPurchBg.SetActive(true); //show upgrade purchase screen
            upgradePurchDesc.text = "Headstart\n Start off with a headstart of random 100-500 score \n Price: $1000"; //show product description
        }
        else if (menuButtons.menuMode==6){
            upgradesEquBg.SetActive(true);
            //check if upgrade is owned
            if (PlayerPrefs.GetInt("upgradeOne", 0)==1){
                upgradeEquDesc.text = "Equip Headstart\n You own this upgrade"; //show upgrade description saying they own upgrade
            }
            else{
                upgradeEquDesc.text = "Equip Headstart\n You do not own this upgrade"; //show upgrade description saying they don't own upgrade
            }
        }

    }

    //when second upgrade is chosen (10% chance of revive)
    public void upgradeTwoClick(){
        upgradeView=2; //current viewing 2nd upgrade

        if (menuButtons.menuMode==4){
            upgradesPurchBg.SetActive(true); //show upgrade purchase screen
            upgradePurchDesc.text = "Infinite Lives\n Have a 10% chance of randomly reviving each death (does not use up the revive for that round)\n Price: $1500"; //show product description
        }
        else if (menuButtons.menuMode==6){
            upgradesEquBg.SetActive(true);
            //check if upgrade is owned
            if (PlayerPrefs.GetInt("upgradeTwo", 0)==1){
                upgradeEquDesc.text = "Equip Infinite Lives\n You own this upgrade"; //show upgrade description saying they own upgrade
            }
            else{
                upgradeEquDesc.text = "Equip Infinite Lives\n You do not own this upgrade"; //show upgrade description saying they don't own upgrade
            }
        }

    }

    //when third upgrade is chosen (better powerups)
    public void upgradeThreeClick(){
        
        upgradeView=3; //current viewing 3rd upgrade

        if (menuButtons.menuMode==4){
            upgradesPurchBg.SetActive(true); //show upgrade purchase screen
            upgradePurchDesc.text = "Better Powerups\n Powerups now add +1000 to your score rather than 500\n Price: $3000"; //show product description
        }
        else if (menuButtons.menuMode==6){
            upgradesEquBg.SetActive(true);
            //check if upgrade is owned
            if (PlayerPrefs.GetInt("upgradeThree", 0)==1){
                upgradeEquDesc.text = "Better Powerups\n You own this upgrade"; //show upgrade description saying they own upgrade
            }
            else{
                upgradeEquDesc.text = "Better Powerups\n You do not own this upgrade"; //show upgrade description saying they don't own upgrade
            }
        }

    }

    //when fourth upgrade is chosen
    public void upgradeFourClick(){
        upgradeView=4; //current viewing 2nd upgrade

        if (menuButtons.menuMode==4){
            upgradesPurchBg.SetActive(true); //show upgrade purchase screen
            upgradePurchDesc.text = "Money Money Money!\n You earn 2x as much money each round\n Price: $5000"; //show product description
        }
        else if (menuButtons.menuMode==6){
            upgradesEquBg.SetActive(true);
            //check if upgrade is owned
            if (PlayerPrefs.GetInt("upgradeFour", 0)==1){
                upgradeEquDesc.text = "Equip Money Money Money!\n You own this upgrade"; //show upgrade description saying they own upgrade
            }
            else{
                upgradeEquDesc.text = "Equip Money Money Money\n You do not own this upgrade"; //show upgrade description saying they don't own upgrade
            }
        }

    }

    //when cancel button is clicked
    public void cancelButtonClick(){
        upgradesPurchBg.SetActive(false); //hide upgrade purchase screen
        upgradesEquBg.SetActive(false); //hide upgrade equip screen
    }

    //when purchase button is clicked
    public void purchaseButtonClick(){

        //check current upgrade being viewed:

        //if it is deafult upgrade
        if (upgradeView==0){

            // always return already owned for deafult upgrade
            StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
        }

        //if it is first upgrade
        else if (upgradeView==1){

            //check if upgrade one is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("upgradeOne", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if upgrade isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 1000)){

                    //subtract 500 coins from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-1000);

                    //set upgradeOne to true as it is now owned
                    PlayerPrefs.SetInt("upgradeOne", 1);

                    //return upgrade purchased
                    StartCoroutine(fadeOutText(purchaseText,"upgrade Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }

        //if it is second upgrade
        else if (upgradeView==2){

            //check if upgrade two is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("upgradeTwo", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if upgrade isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 1500)){

                    //subtract 1000 from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-1500);

                    //set upgradeTwo to true as it is now owned
                    PlayerPrefs.SetInt("upgradeTwo", 1);

                    //return upgrade purchased
                    StartCoroutine(fadeOutText(purchaseText,"upgrade Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }

        //if it is third upgrade
        else if (upgradeView==3){

            //check if upgrade three is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("upgradeThree", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if upgrade isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 3000)){

                    //subtract 2000 from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-3000);

                    //set upgradeTwo to true as it is now owned
                    PlayerPrefs.SetInt("upgradeThree", 1);

                    //return upgrade purchased
                    StartCoroutine(fadeOutText(purchaseText,"upgrade Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }

        //if it is fourth upgrade
        else if (upgradeView==4){

            //check if upgrade three is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("upgradeFour", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if upgrade isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 5000)){

                    //subtract 5000 from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-5000);

                    //set upgradeTwo to true as it is now owned
                    PlayerPrefs.SetInt("upgradeFour", 1);

                    //return upgrade purchased
                    StartCoroutine(fadeOutText(purchaseText,"upgrade Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }
    }

    //function triggered when equip button is clicked
    public void equipButtonClick(){

        //if deafult upgrade is current upgrade being viewed
        if (upgradeView==0){

            //set current upgrade to deafult upgrade
            PlayerPrefs.SetInt("currentupgrade",0);
            StartCoroutine(fadeOutText(equipText,"upgrade Equipped")); // return upgrade equipped

        }

        //if upgrade one is current upgrade being viewed
        if (upgradeView==1){

            //check if player owns upgrade
            if (PlayerPrefs.GetInt("upgradeOne", 0)==1){

                PlayerPrefs.SetInt("currentupgrade",1); // Select upgrade one
                StartCoroutine(fadeOutText(equipText,"upgrade Equipped")); // return upgrade equipped
            }
            else{
                //if upgrade not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }

        //if upgrade two is current upgrade being viewed
        if (upgradeView==2){

            //check if player owns upgrade
            if (PlayerPrefs.GetInt("upgradeTwo", 0)==1){

                PlayerPrefs.SetInt("currentupgrade",2); // Select upgrade two
                StartCoroutine(fadeOutText(equipText,"upgrade Equipped")); // return upgrade equipped
            }
            else{
                //if upgrade not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }

        //if upgrade three is current upgrade being viewed
        if (upgradeView==3){

            //check if player owns upgrade
            if (PlayerPrefs.GetInt("upgradeThree", 0)==1){

                PlayerPrefs.SetInt("currentupgrade",3); // Select upgrade three
                StartCoroutine(fadeOutText(equipText,"upgrade Equipped")); // return upgrade equipped
            }
            else{
                //if upgrade not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }

        //if upgrade four is current upgrade being viewed
        if (upgradeView==4){

            //check if player owns upgrade
            if (PlayerPrefs.GetInt("upgradeFour", 0)==1){

                PlayerPrefs.SetInt("currentupgrade",4); // Select upgrade four
                StartCoroutine(fadeOutText(equipText,"upgrade Equipped")); // return upgrade equipped
            }
            else{
                //if upgrade not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }
    }

    private IEnumerator fadeOutText(TextMeshProUGUI textComponent, string message)
    {
        // Set the message text
        textComponent.text = message;
        // Make sure the text is visible
        textComponent.gameObject.SetActive(true);

        // Store the original color of the text
        Color originalColor = textComponent.color;

        // Wait for .7 seconds before starting the fade-out process
        yield return new WaitForSeconds(0.7f);

        // Duration over which the text will fade out
        float fadeDuration = 1.5f;

        // Timer to track the fading process
        float fadeOutTime = 0f;

        // Gradually reduce the alpha value of the text color over the fadeDuration
        while (fadeOutTime < fadeDuration)
        {
            // Increment the fade out timer by the time elapsed since the last frame
            fadeOutTime += Time.deltaTime;
            // Calculate the new alpha value using linear interpolation
            float alpha = Mathf.Lerp(1.5f, 0f, fadeOutTime / fadeDuration);
            // Update the text color with the new alpha value
            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            // Wait until the next frame before continuing the loop
            yield return null;
        }

        // Hide the text once the fade out is complete
        textComponent.gameObject.SetActive(false);
        // Reset the text color to the original color
        textComponent.color = originalColor;
    }


}
