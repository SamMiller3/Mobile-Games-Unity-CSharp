using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //import textmesh pro library

public class manageSkins : MonoBehaviour
{
    //skin container (all skins and scrollbar are children of this gameobject
    //so will be set active if the gameobject is active, hide if gameobject is hidden)
    public GameObject skins;


    public Scrollbar scrollbar; // Reference to the scrollbar
    public RectTransform skinsContainer; // Reference to the RectTransform of the container holding the skins game objects
    private float scrollHeight = -600f; // Height over which the objects should scroll (negative as it will be scrolling DOWN)

    public GameObject skinsPurchBg; //purchaseMenu for skins
    public TextMeshProUGUI skinPurchDesc; // reference to product description
    private int skinView = 0; // current skin being viewed

    public GameObject skinsEquBg; //purchaseMenu for skins
    public TextMeshProUGUI skinEquDesc; // reference to description of skin to equip

    public TextMeshProUGUI equipText; // Reference text which will show up when you attempt to equip a skin
    public TextMeshProUGUI purchaseText; // Reference text which will show up when you purchase a skin

    private float initialPositionY;



    // Update is called once per frame
    void Update()
    {
        //if on menu mode 5 or 7 (shop/equip skins) show skins container
        if (menuButtons.menuMode==5||menuButtons.menuMode==7){
            skins.SetActive(true);
        }
        //otherwise hide
        else{
            skins.SetActive(false);
        }


        // Calculate the new Y position for the content container based on the scrollbar value.
        // Mathf.Lerp linearly interpolates between the initial Y position and the target Y position (initialPositionY - scrollHeight).
        // The interpolation factor is determined by the scrollbar value (0.0 to 1.0).
        float newY = Mathf.Lerp(initialPositionY, initialPositionY - scrollHeight, scrollbar.value);

        // Update the anchored position of the content container with the new Y position.
        // The X position remains unchanged.
        skinsContainer.anchoredPosition = new Vector2(skinsContainer.anchoredPosition.x, newY);

    }

    //when deafult skin is chosen
    public void deafultSkinClick(){

        skinView=0; //current viewing 0th skin

        if (menuButtons.menuMode==5){
            skinsPurchBg.SetActive(true); //show skin purchase screen
            skinPurchDesc.text = "Default Skin\n Price: $0"; //show product description
        }
        else if (menuButtons.menuMode==7){
            skinsEquBg.SetActive(true);
            skinEquDesc.text = "Equip Default Skin\n You own this skin"; //show skin description
        }
    }

    //when first skin is chosen
    public void skinOneClick(){
        
        skinView=1; //current viewing 1st skin

        if (menuButtons.menuMode==5){
            skinsPurchBg.SetActive(true); //show skin purchase screen
            skinPurchDesc.text = "Skin 1\n Price: $500"; //show product description
        }
        else if (menuButtons.menuMode==7){
            skinsEquBg.SetActive(true);
            //check if skin is owned
            if (PlayerPrefs.GetInt("skinOne", 0)==1){
                skinEquDesc.text = "Equip Skin 1\n You own this skin"; //show skin description saying they own skin
            }
            else{
                skinEquDesc.text = "Equip Skin 1\n You do not own this skin"; //show skin description saying they don't own skin
            }
        }

    }

    //when second skin is chosen
    public void skinTwoClick(){
        skinView=2; //current viewing 2nd skin

        if (menuButtons.menuMode==5){
            skinsPurchBg.SetActive(true); //show skin purchase screen
            skinPurchDesc.text = "Skin 2\n Price: $1000"; //show product description
        }
        else if (menuButtons.menuMode==7){
            skinsEquBg.SetActive(true);
            //check if skin is owned
            if (PlayerPrefs.GetInt("skinTwo", 0)==1){
                skinEquDesc.text = "Equip Skin 2\n You own this skin"; //show skin description saying they own skin
            }
            else{
                skinEquDesc.text = "Equip Skin 2\n You do not own this skin"; //show skin description saying they don't own skin
            }
        }

    }

    //when third skin is chosen
    public void skinThreeClick(){
        
        skinView=3; //current viewing 3rd skin

        if (menuButtons.menuMode==5){
            skinsPurchBg.SetActive(true); //show skin purchase screen
            skinPurchDesc.text = "Skin 3\n Price: $2000"; //show product description
        }
        else if (menuButtons.menuMode==7){
            skinsEquBg.SetActive(true);
            //check if skin is owned
            if (PlayerPrefs.GetInt("skinThree", 0)==1){
                skinEquDesc.text = "Skin 3\n You own this skin"; //show skin description saying they own skin
            }
            else{
                skinEquDesc.text = "Skin 3\n You do not own this skin"; //show skin description saying they don't own skin
            }
        }

    }

    //when fourth skin is chosen
    public void skinFourClick(){
        skinView=4; //current viewing 2nd skin

        if (menuButtons.menuMode==5){
            skinsPurchBg.SetActive(true); //show skin purchase screen
            skinPurchDesc.text = "Skin 4\n Price: $5000"; //show product description
        }
        else if (menuButtons.menuMode==7){
            skinsEquBg.SetActive(true);
            //check if skin is owned
            if (PlayerPrefs.GetInt("skinFour", 0)==1){
                skinEquDesc.text = "Skin 4\n You own this skin"; //show skin description saying they own skin
            }
            else{
                skinEquDesc.text = "Equip Skin 4\n You do not own this skin"; //show skin description saying they don't own skin
            }
        }

    }

    //when cancel button is clicked
    public void cancelButtonClick(){
        skinsPurchBg.SetActive(false); //hide skin purchase screen
        skinsEquBg.SetActive(false); //hide skin equip screen
    }

    //when purchase button is clicked
    public void purchaseButtonClick(){

        //check current skin being viewed:

        //if it is deafult skin
        if (skinView==0){

            // always return already owned for deafult skin
            StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
        }

        //if it is first skin
        else if (skinView==1){

            //check if skin one is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("skinOne", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if skin isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 500)){

                    //subtract 500 coins from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-500);

                    //set skinOne to true as it is now owned
                    PlayerPrefs.SetInt("skinOne", 1);

                    //return skin purchased
                    StartCoroutine(fadeOutText(purchaseText,"Skin Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }

        //if it is second skin
        else if (skinView==2){

            //check if skin two is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("skinTwo", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if skin isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 1000)){

                    //subtract 1000 from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-1000);

                    //set skinTwo to true as it is now owned
                    PlayerPrefs.SetInt("skinTwo", 1);

                    //return skin purchased
                    StartCoroutine(fadeOutText(purchaseText,"Skin Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }

        //if it is third skin
        else if (skinView==3){

            //check if skin three is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("skinThree", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if skin isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 2000)){

                    //subtract 2000 from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-2000);

                    //set skinTwo to true as it is now owned
                    PlayerPrefs.SetInt("skinThree", 1);

                    //return skin purchased
                    StartCoroutine(fadeOutText(purchaseText,"Skin Purchased"));


                }

                else{
                    
                    //return insufficient coins as they do do not have enough money
                    StartCoroutine(fadeOutText(purchaseText,"Insufficient Coins"));

                }

            }
            
        }

        //if it is fourth skin
        else if (skinView==4){

            //check if skin three is owned, if so return Already Owned
            if (PlayerPrefs.GetInt("skinFour", 0)==1){
                StartCoroutine(fadeOutText(purchaseText,"Already Owned"));
            }
            else{

                //if skin isnt owned check if they have enough money
                if (( PlayerPrefs.GetInt("coins", 0) >= 5000)){

                    //subtract 5000 from their total coins
                    PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)-5000);

                    //set skinTwo to true as it is now owned
                    PlayerPrefs.SetInt("skinFour", 1);

                    //return skin purchased
                    StartCoroutine(fadeOutText(purchaseText,"Skin Purchased"));


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

        //if deafult skin is current skin being viewed
        if (skinView==0){

            //set current skin to deafult skin
            PlayerPrefs.SetInt("currentSkin",0);
            StartCoroutine(fadeOutText(equipText,"Skin Equipped")); // return skin equipped

        }

        //if skin one is current skin being viewed
        if (skinView==1){

            //check if player owns skin
            if (PlayerPrefs.GetInt("skinOne", 0)==1){

                PlayerPrefs.SetInt("currentSkin",1); // Select skin one
                StartCoroutine(fadeOutText(equipText,"Skin Equipped")); // return skin equipped
            }
            else{
                //if skin not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }

        //if skin two is current skin being viewed
        if (skinView==2){

            //check if player owns skin
            if (PlayerPrefs.GetInt("skinTwo", 0)==1){

                PlayerPrefs.SetInt("currentSkin",2); // Select skin two
                StartCoroutine(fadeOutText(equipText,"Skin Equipped")); // return skin equipped
            }
            else{
                //if skin not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }

        //if skin three is current skin being viewed
        if (skinView==3){

            //check if player owns skin
            if (PlayerPrefs.GetInt("skinThree", 0)==1){

                PlayerPrefs.SetInt("currentSkin",3); // Select skin three
                StartCoroutine(fadeOutText(equipText,"Skin Equipped")); // return skin equipped
            }
            else{
                //if skin not owned return "Not Owned"
                StartCoroutine(fadeOutText(equipText,"Not Owned"));
            }

        }

        //if skin four is current skin being viewed
        if (skinView==4){

            //check if player owns skin
            if (PlayerPrefs.GetInt("skinFour", 0)==1){

                PlayerPrefs.SetInt("currentSkin",4); // Select skin four
                StartCoroutine(fadeOutText(equipText,"Skin Equipped")); // return skin equipped
            }
            else{
                //if skin not owned return "Not Owned"
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
