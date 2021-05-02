using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoTouch : MonoBehaviour
{
    public GameObject sky;
    public GameObject camera;
    private Rigidbody2D rb;
    private float i;
    private int move;
    // Start is called before the first frame update
    void Start()
    {
        colMenu.go =1;
        move = Random.Range(1,3);
        camera.transform.position = new Vector3(0,0,-10);
        sky.transform.position = new Vector3(0,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 3.5 && colMenu.go != 2){
            transform.position = new Vector3(transform.position.x,-3.56f,-2);
        }
        if (transform.position.x > 2.7f){
            transform.position = new Vector3(2.69f,-3.56f,-1);
        }
        if (transform.position.x < -2.7f){
            transform.position = new Vector3(-2.69f,-3.56f,-1);
        }
        if (colMenu.shie == 1){
            transform.position = new Vector3(transform.position.x, -3.56f, -2);
        }
        if (pause.paused == 0){
                if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch (0);
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));
                if (transform.position.x - touchPosition.x < 1 && transform.position.x - touchPosition.x > -1){
                    if(touchPosition.x < 1.9f || touchPosition.y < 4){
                    if (touchPosition.x > transform.position.x){
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                if (touchPosition.x < transform.position.x){
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                transform.position = new Vector3(touchPosition.x , -3.56f, -1);
                }
                }
            }
    }    
        }
        if (pause.paused == 1 && colMenu.go ==2){
            i=0.1f;
            i+=Random.Range(0.009f,0.007f) * Time.deltaTime;
            transform.position = transform.position-new Vector3(0,i,0);
            camera.transform.position = camera.transform.position-new Vector3(0,i,0);
            sky.transform.position = sky.transform.position-new Vector3(0,i,0);
            if (move == 1){
            transform.Rotate(0,0,-3.56f);
            }
            else{
                transform.Rotate(0,0,3f);
            }
        }
}
}
