using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // assembly reference to TMPro to manage text

public class missions : MonoBehaviour
{
    public TextMeshProUGUI missionText; // reference to missionText so it can be modified later
    public GameObject rewardClaimed; // reference to game object text which shows up when you claim mission reward to be able to enable/disable it
    public TextMeshProUGUI rewardClaimedText; // reference to text which shows up when you claim a mission reward to update it later


    // Start is called before the first frame update
    void Start()
    {
        rewardClaimed.SetActive(false); // hide the reward claimed text on scene start

        //check if no mission is set (is equal to default value)
        if (PlayerPrefs.GetString("mission","no mission") == "no mission")
        {
            // generate a new mission
            
            string newMission=generateMissions();
            PlayerPrefs.SetString("mission", newMission);

            }

            // change mission text to display mission
            missionText.text = PlayerPrefs.GetString("mission", "no mission");
        }



    public void claimButtonClick() // function called when claim button clicked
    {
        if (validateMissionComplete()) // check if mission is completed
        {

            string textOutput="Reward Claimed: "; // set output to Reward Claimed:
            int coinsEarnt = Mathf.RoundToInt(UnityEngine.Random.Range(50,500) / 50.0f) * 50; // Choose random number between 50 to 500 rounded to 50 for coins earnt
            textOutput+=coinsEarnt.ToString(); // Add this to message
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0)+coinsEarnt); // add number of coins earnt to total number of coins
            StartCoroutine(showText(textOutput)); //show text output to player

            //generate a new mission:
            string newMission=generateMissions();
            PlayerPrefs.SetString("mission", newMission);

            // change mission text to display mission
            missionText.text = PlayerPrefs.GetString("mission", "no mission");
        }
        else{
            StartCoroutine(showText("Mission not Completed")); //show text saying mission is not completed
        }
    }


    private bool validateMissionComplete(){

        if (PlayerPrefs.GetInt("missionType", 0) == 1){ // check if mission type is a Score Over <number> mission:
            
            if (calcScore.score > PlayerPrefs.GetInt("missionOperand", 0)){ // if so check if score in last round exceeds mission operand

                return(true); //if so return true

            }
            else{

                return(false); //otherwise return false

            }
        }

        else if (PlayerPrefs.GetInt("missionType", 0) ==2){ // check if mission type is a Collect Over <number> coins mission:
            
            if (PlayerPrefs.GetInt("coins", 0) > PlayerPrefs.GetInt("missionOperand", 0)){ // if so check if num of coins is greater than mission operand

                return(true); //if so return true
                
            }
            else{

                return(false); //otherwise return false

            }
        }

        else if (PlayerPrefs.GetInt("missionType", 0) ==3){ // check if mission type is a get hit by a blackhole mission:
            
            if (Blackhole.hitByBlackhole){ // if so check if hit by a blackhole last round

                return(true); //if so return true
                
            }
            else{

                return(false); //otherwise return false

            }
        }

        else if (PlayerPrefs.GetInt("missionType", 0) ==4){ // check if mission type is collect <number> powerups:
            
            if (game.powerUpsCollected > PlayerPrefs.GetInt("missionOperand", 0)){ // if so check if powerups collected last round exceeds mission operand

                return(true); //if so return true
                
            }
            else{

                return(false); //otherwise return false

            }
        }

        else if (PlayerPrefs.GetInt("missionType", 0) ==5){ // check if mission type is get new high score:
            
            if (calcScore.score==PlayerPrefs.GetInt("highscore", 0)){ // if so check if score last round is highscore

                return(true); //if so return true
                
            }
            else{

                return(false); //otherwise return false

            }
        }

        //otherwise return false
        return false;

    }

    private IEnumerator showText(string message){
        // Set the message text
        rewardClaimedText.text = message;
        // Make sure the text is visible
        rewardClaimedText.gameObject.SetActive(true);

        // Store the original color of the text
        Color originalColor = rewardClaimedText.color;

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
            rewardClaimedText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            // Wait until the next frame before continuing the loop
            yield return null;
        }

        // Hide the text once the fade out is complete
        rewardClaimedText.gameObject.SetActive(false);
        // Reset the text color to the original color
        rewardClaimedText.color = originalColor;
    }

    public string generateMissions(){ // returns string type of mission

        int missionType=UnityEngine.Random.Range(1,6); // random.range goes from first value to last value-1, so random between 1 and 5
        PlayerPrefs.SetInt("missionType", missionType); //store type of mission permenantly

        string mission = "Mission: ";
        int operand = 0;
        switch(missionType){ //depending on the value of mission type execute different cases

            case 1:

                mission+="Score over "; // set str mission to score over:
                operand = Mathf.RoundToInt(UnityEngine.Random.Range(1500,4000) / 100.0f) * 100; //operand is set to a random number 1500-4000 rounded to closest 100
                mission+=operand.ToString();  // cast operand to string and append to mission
                break;

            case 2:

                mission+="Collect over "; // set mission to collect over
                operand= PlayerPrefs.GetInt("coins", 0)+UnityEngine.Random.Range(300,1000); //set operand to random number between 300-1000 and add to current num of coins
                mission+= operand.ToString(); //append a operand cast to string
                mission+= " coins";  //then add coins so the mission is in the form of "collect over <num> coins"
                break;

            case 3:

                mission+=" Get hit by a blackhole" ;
                break;

            case 4:
                mission+=" Collect "; 
                operand = (UnityEngine.Random.Range(2,6)); //operand is set to random number 2-5
                mission+= operand.ToString(); //mission is set to collect <operand> powerups in 1 round
                mission+= " powerups in 1 round";
                break;
            case 5:
                mission+=" Get a new highscore";
                break;
        }
        
        PlayerPrefs.SetInt("missionOperand", operand); // store permenantly the operand of the current mission
        
        return(mission);    //return the mission generated
    }
}
