using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBackground : MonoBehaviour
{
    public GameObject rocket;
    public GameObject balloon;
    void Start(){
        StartCoroutine(spawn());
    }
    IEnumerator spawn(){
        while (1>0){
            yield return new WaitForSeconds(Random.Range(0.6f,2f));
            if (Random.Range(1,12) == 10){
                Instantiate(rocket, new Vector3(Random.Range(-3f,3f),-3,0), Quaternion.Euler(0, 0, -1));
            }
            else{
                Instantiate(balloon, new Vector3(Random.Range(-3f,3f),-3,0), Quaternion.Euler(0, 0, -1));
            }
        }
    }
}
