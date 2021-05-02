using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carsGenerate : MonoBehaviour
{
    public GameObject carGrey;
    public GameObject carRed;
    public GameObject carYellow;
    public GameObject carBlue;
    public GameObject carPink;
    int rand;
    public GameObject petrol;
    public GameObject Truck;
    int randCar;
    void Start()
    {
        ballsButton.sel = true;
        StartCoroutine(gen());
    }
    IEnumerator gen(){
        while (1>0){
            if(pause.Pause && ballsButton.sel){
                rand = Random.Range(1,4);
                if(Random.Range(1,20) != 16){
                    if (rand == 1){
                        if (SceneManager.GetActiveScene().name == "Game"){
                    if(Random.Range(1,20) == 16){
                        if(rand == 1){
                            Instantiate(petrol, new Vector3(7, 2, 20), Quaternion.Euler(0,0,0));
                        }
                        if(rand == 2){
                            Instantiate(petrol, new Vector3(4, 2, 20), Quaternion.Euler(0,0,0));
                        }
                        if(rand == 3){
                            Instantiate(petrol, new Vector3(1, 2, 20), Quaternion.Euler(0,0,0));
                        }
                    }
                }
                randCar = Random.Range(1,6);
                    if(randCar == 1){
                        Instantiate(carGrey, new Vector3(8.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 2){
                        Instantiate(carRed, new Vector3(8.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 3){
                        Instantiate(carPink, new Vector3(8.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 4){
                        Instantiate(carBlue, new Vector3(8.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 5){
                        Instantiate(carYellow, new Vector3(8.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    }
                    if (rand == 2){
                        randCar = Random.Range(1,6);
                        if(randCar == 1){
                        Instantiate(carGrey, new Vector3(5.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 2){
                        Instantiate(carRed, new Vector3(5.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 3){
                        Instantiate(carPink, new Vector3(5.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 4){
                        Instantiate(carBlue, new Vector3(5.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 5){
                        Instantiate(carYellow, new Vector3(5.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    }
                    if (rand == 3){
                        randCar = Random.Range(1,6);
                        if(randCar == 1){
                        Instantiate(carGrey, new Vector3(2.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 2){
                        Instantiate(carRed, new Vector3(2.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 3){
                        Instantiate(carYellow, new Vector3(2.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 4){
                        Instantiate(carBlue, new Vector3(2.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                    if(randCar == 5){
                        Instantiate(carPink, new Vector3(2.25f, 0.5f, 20), Quaternion.Euler(0,0,0));
                    }
                }
                yield return new WaitForSeconds(0.47f);
                }
                else{
                    if (SceneManager.GetActiveScene().name == "Game"){
                    if(Random.Range(1,20) == 16){
                        if(rand == 1){
                            Instantiate(petrol, new Vector3(1, 3.45f, 20), Quaternion.Euler(0,0,0));
                        }
                        if(rand == 2){
                            Instantiate(petrol, new Vector3(4, 3.45f, 20), Quaternion.Euler(0,0,0));
                        }
                        if(rand == 3){
                            Instantiate(petrol, new Vector3(7, 3.45f, 20), Quaternion.Euler(0,0,0));
                        }
                    }
                }
                    if(rand == 1){
                        Instantiate(Truck, new Vector3(1, 1, 20), Quaternion.Euler(0,180,0));
                    }
                    if(rand == 2){
                        Instantiate(Truck, new Vector3(4, 1, 20), Quaternion.Euler(0,180,0));
                    }
                    if(rand == 3){
                        Instantiate(Truck, new Vector3(7, 1, 20), Quaternion.Euler(0,180,0));
                    }
                    yield return new WaitForSeconds(.7f);
                }
            }
            else{
                yield return null;
            }
        }
    }
}
