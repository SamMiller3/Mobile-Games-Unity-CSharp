using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using UnityEngine.UI; //to control texture
using TMPro; // to control text

public class game : MonoBehaviour
{
    //gameobjects
    public GameObject asteroid;
    public GameObject star;
    public GameObject blackhole;
    public GameObject powerup;
    public GameObject forceField;
    public GameObject powerUpScore;

    //Text:
    public TextMeshProUGUI powerUpScoreText; // text which shows saying +500 score or +1000 score when powerup is used

    //Reference ships texture:
    public SpriteRenderer shipSpriteRenderer; // Reference to the ship's SpriteRenderer 
    public Sprite[] shipSprites; // Array of ship Sprites (will add the sprites in unity inspector editor)

    //Reference polygon colliders 2D:
    public PolygonCollider2D defaultCollider; //polygon collider 2D for default skin
    public PolygonCollider2D secondCollider; //polygon collider 2D for skins 1, 2 and 3
    public PolygonCollider2D thirdCollider; //polygon collider 2D for skin 4

    //vars
    public float MODIFIER;
    private int numAsteroids;
    public static int powerUpsCollected;

    // Start is called before the first frame update
    void Start()
    {
        //set powerups collected to 0:
        powerUpsCollected=0;

        //call coroutines when scene opens
        StartCoroutine(genAsteroids());
        StartCoroutine(genStars());
        StartCoroutine(genBlackHole());
        StartCoroutine(genPowerUps());

        //show correct texture for ship when scene opens:
        int currentSkinIndex = PlayerPrefs.GetInt("currentSkin", 0); // set playerpref to an int so it can be used in script, default to 0 if not set
        shipSpriteRenderer.sprite = shipSprites[currentSkinIndex]; // set current sprite to current index in ship sprites

        //enable correct polygon collider and disable incorrect ones of equipped skin:
        if (PlayerPrefs.GetInt("currentSkin", 0)==0){ // if it is default
            defaultCollider.enabled = true; // enable default collider disable rest
            secondCollider.enabled = false;
            thirdCollider.enabled = false;
        }

        else if ((PlayerPrefs.GetInt("currentSkin", 0)==1) || (PlayerPrefs.GetInt("currentSkin", 0)==2) || (PlayerPrefs.GetInt("currentSkin", 0)==3)){
            //if it is skin 1, 2 or 3 enable second collider disable rest
            defaultCollider.enabled = false;
            secondCollider.enabled = true;
            thirdCollider.enabled = false;
        }

        else{
            //otherwise it must be skin 4 so disable all colliders except third
            defaultCollider.enabled = false;
            secondCollider.enabled = false;
            thirdCollider.enabled = true;
        }


        powerupMove.powerUpSpeed=1; // when scene starts set powerup speed to 1
    }

    // Update is called once per frame
    void Update()
    {

        //check if powerup in use
        if (powerupMove.powerUpSpeed==1){ //if not
            forceField.SetActive(false); //hide forcefield
            powerUpScore.SetActive(false); //hide + score text
        }
        else{ //if it is:
             forceField.SetActive(true); //show forcefield
             powerUpScore.SetActive(true); //show + score text

             //check if current upgrade equipped is better powerups:
             if (PlayerPrefs.GetInt("currentupgrade",0)==3){
                //if so show +1000 score
                powerUpScoreText.text="+1000 SCORE";
             }
             else{
                //otherwise show default +500 score
                powerUpScoreText.text="+500 SCORE";
             }
        }

        //check game is not paused
        if(pause.Pause){

            //then get coordinates of mouse
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
            //make sure mouse pos is in allowed position
            if (mouseWorldPos.y < 5 && mouseWorldPos.y>-5)
                {
                    //change pos to mouse y: 
                    
                    //if power up disabled go to mouse y
                    //otherwise go 1 ahead on z axis so not to interact with forcefield or any incoming obstacles
                    //(-1 is 1 ahead as camera position is at z -10)
                    //also move forcefield to mouse y
                    if (powerupMove.powerUpSpeed==1){

                        transform.position = new Vector3(-7,mouseWorldPos.y,0);

                    }
                    else{

                        transform.position = new Vector3(-7,mouseWorldPos.y,-1);
                        forceField.transform.position = new Vector3(-7,mouseWorldPos.y,0);

                        }
                }       

        }
        

    }


    IEnumerator genBlackHole(){
        //always loop
        while(1>0){

            //when score is greater than 2000 AND game is not paused then gen black holes every random num of seconds
            //otherwise wait until next frame
            
            if(calcScore.score>2000 && pause.Pause){

                yield return new WaitForSeconds(UnityEngine.Random.Range(2,4));

                //make sure game is not paused before generating a blackhole
                if (pause.Pause){
                    Instantiate(blackhole, new Vector3(10,UnityEngine.Random.Range(-4, 4), 1), Quaternion.Euler(0, 0, -1));
                }

            }

            else{

                //skip a frame until not paused
                yield return null;
            }
        }
    }

    IEnumerator genStars(){

        //always generate stars
        while(1>0){

            //check if game is paused, if so then wait random amount of time and generate a star
            if(pause.Pause){

                yield return new WaitForSeconds(UnityEngine.Random.Range(3,6));
                
                //check if paused before generating
                if (pause.Pause){
                    Instantiate(star, new Vector3(9,UnityEngine.Random.Range(-4, 4), 1), Quaternion.Euler(0, 0, -1));
                }

            }
            else{

                //skip a fram until not paused
                yield return null;
            }
        }
    }

    IEnumerator genAsteroids(){
        while (1>0){

            //check if game is paused

            if (pause.Pause){

                //if game is not paused
                //random number of asteroids spawn

                numAsteroids=UnityEngine.Random.Range(1,3); //choose random number of asteroids 1-3

                for (int i = 0; i <= numAsteroids; i = i + 1) //iterate num of asteroids, spawn each one in random y position, on far right of screen
                {

                Instantiate(asteroid, new Vector3(8,UnityEngine.Random.Range(-4.5f, 4.5f), 0), Quaternion.Euler(0, 0, -1));

                }

                //wait a decreasing decreasing amount of time between each new asteroid spawning
                //(proportional to 1/log of score)

                yield return new WaitForSeconds((float) (1/Math.Log(calcScore.score+10,10))*MODIFIER);
                
                }

                else{

                    //skip frame until not paused
                    yield return null;
                }
            }
    }


    IEnumerator genPowerUps(){
        while (1>0){

            //check if game is paused

            if (pause.Pause){

                //make sure game is not paused
                //wait random amount of time then if random number is chosen AND powerup is not currently in use then generate a powerup

                yield return new WaitForSeconds(UnityEngine.Random.Range(4,6));

                if((UnityEngine.Random.Range(1,4))==1 && (powerupMove.powerUpSpeed==1) && pause.Pause) 
                    {

                    //generate powerup on far right of screen, random point on y axis
                    Instantiate(powerup, new Vector3(8,UnityEngine.Random.Range(-4, 4), 0), Quaternion.Euler(0, 0, -1));

                    }
            }

            else{

                //skip frame until not paused
                yield return null;
            }
        }
    }

}
