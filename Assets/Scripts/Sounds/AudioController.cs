using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource meow;
    public AudioSource eat;

    public AudioSource sizzle;
    public AudioSource tada;
    public static AudioController instance;

    public bool isMute = false;
    private void Awake() {
        if(AudioController.instance == null) AudioController.instance = this;
        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start() {
        InvokeRepeating("CatMeow", 2, 10);
    }

    public void MuteAudio(bool mute) {
        isMute = mute;
        if(!mute)
            mixer.SetFloat("MasterVolume", -80);
        else mixer.SetFloat("MasterVolume", 0);
    }

    public void CatMeow()  {
        meow.Play();
    }

    public void EatSFX()   {
        eat.Play();
    }
    
    public void TadaEnd()
    {
        tada.Play();
    }
}
