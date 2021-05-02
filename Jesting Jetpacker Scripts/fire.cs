using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject gas;
    void Start()
    {
        InvokeRepeating("createGas", 0.1f, 0.07f);
    }

    void createGas()
    {
        if (pause.paused == 0){
            if (this.transform.rotation.eulerAngles.y == 0){
        Instantiate(gas, new Vector3(this.transform.position.x + Random.Range(-0.22f, -0.11f), -3.76f, -1), Quaternion.Euler(0,0,0));
        }
        if (this.transform.rotation.eulerAngles.y == 180){
        Instantiate(gas, new Vector3(this.transform.position.x + Random.Range(0.22f, 0.11f), -3.76f, -1), Quaternion.Euler(0,0,0));
        }
        }
    }
}
