using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class playMusic : MonoBehaviour
{
    public AudioClip start;
    public AudioClip loop;
    AudioSource audioSource;
    void Update(){
        if(audioOn.audio == 1){
            audioSource.Stop();
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioOn.audio == 0){
            audioSource.PlayOneShot(start);
        }
        StartCoroutine(play());
    }
    IEnumerator play(){
        yield return new WaitForSeconds(3);
        while (1>0){
        if (audioOn.audio == 0){
                audioSource.PlayOneShot(loop);
        yield return new WaitForSeconds(13);
            }
            else{
                yield return null;
            }
        }
    }
    }

