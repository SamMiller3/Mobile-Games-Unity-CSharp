using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuRocket : MonoBehaviour
{
    private float speed;
    void Start(){
        speed = Random.Range(2.6f,3.3f);
    }
    void Update()
    {
        transform.position = transform.position + new Vector3(0, speed * Time.deltaTime,0);
        if (transform.position.y > 7.4f){
            Destroy(this.gameObject);
        }
    }
}
