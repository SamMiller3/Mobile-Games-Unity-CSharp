using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuJetpack : MonoBehaviour
{
    private int i = 0; 
    private int m;
    void Start(){
        
        transform.position = new Vector3(Random.Range(-3,3),Random.Range(-6,6),0);
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360));
    }
    void Update()
    {
        if (i > Random.Range(200,300)  || transform.position.x > 3   || transform.position.x < -3 || transform.position.y > 5   || transform.position.y < -5){
                m = 0;
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(1,360));
            }
            if (transform.position.x > 8){
                transform.position = transform.position + new Vector3(-0.1f, 0, 0);
                m = 0;
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(1,360));
            }
            if (transform.position.x < -8){
                transform.position = transform.position + new Vector3(0.1f, 0, 0);
                m = 0;
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(1,360));
            }
             if (transform.position.y > 3){
                transform.position = transform.position + new Vector3(0, -0.1f, 0);
                m = 0;
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(1,360));
            }
            if (transform.position.y < -3){
                transform.position = transform.position + new Vector3(0, 0.1f, 0);
                m = 0;
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(1,360));
            }
            if (m== 0){
                i = 0;
                m = 1;
            }
            transform.position += transform.up * Time.deltaTime * 0.7f;
            i++;
    }
}
