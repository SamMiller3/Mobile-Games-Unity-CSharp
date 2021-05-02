using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -3.7f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -7){
            Destroy(this.gameObject);
        }
        if (pause.paused == 0){
            transform.position = transform.position + new Vector3(0,(-2f * Time.deltaTime),0);
        }
    }
}
