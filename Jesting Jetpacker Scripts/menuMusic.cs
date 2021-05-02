using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class menuMusic : MonoBehaviour
{
   public AudioClip menu;
    AudioSource audioSource;
    int i;

void Update(){
        if(audioOn.audio == 1){
            audioSource.Stop();
        }
    }
    IEnumerator Start(){
        audioSource = GetComponent<AudioSource>();
        while (1>0){
            if (audioOn.audio == 0){
                i = 0;
                audioSource.PlayOneShot(menu);
                while (i < 160){
                    if(audioOn.audio == 0){
                        yield return new WaitForSeconds(0.1f);
                    i++;
                    }
                    else{
                        i = 160;
                    }
                }
            }
            else{
                yield return null;
            }
        }
    }
}
