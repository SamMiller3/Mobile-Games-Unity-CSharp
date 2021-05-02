using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;
public class gotoTouch : MonoBehaviour, IUnityAdsListener
{
    public GameObject getPoints;
    public Text PlusPoints;
    public Material skin1;
    public Material skin2;
    public Material skin3;
    public Material skin4;
    public GameObject skip;
    public GameObject reviveButton;
    public GameObject ps;
    public GameObject ball;
    int revived;
    void Start(){
        revived = 0;
        skip.SetActive(false);
        reviveButton.SetActive(false);
        StartCoroutine(lubirateJump());
        getPoints.SetActive(false);
        ps.SetActive(true);
    }
    IEnumerator lubirateJump(){
        while (1>0){
            if(transform.position.y < 4){
                yield return new WaitForSeconds(0.5f);
                if (transform.position.y < 5){
                    yield return new WaitForSeconds(0.5f);
                    if(transform.position.y < 4){
                        yield return new WaitForSeconds(0.5f);
                        if(transform.position.y < 4){
                            transform.position = new Vector3(transform.position.x,5.2f,transform.position.z);
                        }
                    }
                }
            }
            yield return null;
        }
    }
    IEnumerator Petrol(){
        getPoints.SetActive(true);
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                PlusPoints.color = new Color(0.811022f, 0.1607843f, 0.9921569f, i);
                yield return null;
            }
            getPoints.SetActive(false);
    }
    public void OnUnityAdsDidStart(string placementId){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsReady(string placementId){
        throw new System.NotImplementedException();
    }
    public void OnUnityAdsDidError(string placementId){
        ball.SetActive(false);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult){
        if (showResult == ShowResult.Finished){
            Revive();
        }
    }
    public void Revive(){   
            revived = 1;
            pause.Pause = true;
            ps.SetActive(true);
            ball.SetActive(true);
            this.transform.position = new Vector3(4, 5.2f, -1.405827f);
            skip.SetActive(false);
            reviveButton.SetActive(false);
            
    }
    public void displayAd(){
        ball.SetActive(true);
        StartCoroutine(showAd());
    }
    IEnumerator showAd(){
        Advertisement.AddListener(this);
        Advertisement.Initialize("4089649", true);
        while (!Advertisement.IsReady("rewardedVideo")){
            yield return null;
        }
        Advertisement.Show("rewardedVideo");
    }
    public void skipClick(){
        SceneManager.LoadScene("Menu");
    }
     void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("road")) {
                PlayerPrefs.SetInt("ThreeTimesAgo", PlayerPrefs.GetInt("TwoTimesAgo", 0));
                    PlayerPrefs.SetInt("TwoTimesAgo", PlayerPrefs.GetInt("pastScore", 0));
                    PlayerPrefs.SetInt("pastScore", score.Score);
                    PlayerPrefs.SetInt("averageScore", ((PlayerPrefs.GetInt("TwoTimesAgo", 0) + PlayerPrefs.GetInt("pastScore", 0) + PlayerPrefs.GetInt("ThreeTimesAgo", 0)))/3);
                    if(revived == 0){
                        reviveButton.SetActive(true);
                    skip.SetActive(true);
                    pause.Pause = false;
                    ball.SetActive(false);
                    ps.SetActive(false);
                    }
                    else{
                        SceneManager.LoadScene("Menu");
                    }
                }
        if(col.gameObject.CompareTag("car")){
            PlayerPrefs.SetInt("carsBounced", PlayerPrefs.GetInt("carsBounced", 0)+1);
            score.Score++;
        }
        if(col.gameObject.CompareTag("truck")){
            PlayerPrefs.SetInt("trucksBounced", PlayerPrefs.GetInt("trucksBounced", 0)+1);
            score.Score++;
        }
        if(col.gameObject.CompareTag("petrol")){
            PlayerPrefs.SetInt("PetrolCollected", PlayerPrefs.GetInt("PetrolCollected", 0)+1);
            Destroy(col.gameObject);
            score.Score+=5;
            StartCoroutine(Petrol());
        }
        }
    void Update()
    {
        if(PlayerPrefs.GetInt("skin", 1) == 1){
            this.gameObject.GetComponent<MeshRenderer>().material = skin1;
        }
        if(PlayerPrefs.GetInt("skin", 1) == 2){
            this.gameObject.GetComponent<MeshRenderer>().material = skin2;
        }
        if(PlayerPrefs.GetInt("skin", 1) == 3){
            this.gameObject.GetComponent<MeshRenderer>().material = skin3;
        }
        if(PlayerPrefs.GetInt("skin", 1) == 4){
            this.gameObject.GetComponent<MeshRenderer>().material = skin4;
        }
        if(pause.Pause){
               transform.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
        }
        else{
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
        if(transform.position.y < 0){
            SceneManager.LoadScene("Menu");
        }
        if(transform.position.y > 5.2f){
            transform.position = new Vector3(transform.position.x,5.2f,transform.position.z);
        }
        if (Input.touchCount > 0) {
            if (pause.Pause){
                Touch touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));
                if (touchPosition.x - transform.position.x < 1 && touchPosition.x - transform.position.x > -1 ){
                    transform.position = new Vector3(touchPosition.x , transform.position.y, -1.405827f);
                }
    } 
            }
        } 
    }
}
