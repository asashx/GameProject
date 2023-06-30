using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioSource audioSource;

    private bool toggleValue = true;

    public void Click(){
        toggleValue = !toggleValue;
        if(toggleValue){
            PlayMusic();
        }else{
            PauseMusic();
        }
    }
    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }
}
