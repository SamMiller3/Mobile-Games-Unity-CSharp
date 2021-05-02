using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
    void Update()
    {
        if (pause.Pause){
            transform.position = transform.position + new Vector3(0,0,-10f * Time.deltaTime);
            if (transform.position.z < -10){
                Destroy(this.gameObject);
            }
        }
    }
}
