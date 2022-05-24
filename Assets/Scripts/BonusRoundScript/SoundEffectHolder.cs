using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectHolder : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource EatSfx;
    public AudioSource TadaSfx;
    public AudioSource BGSfx;
    public AudioSource MeowSfx;
    public AudioSource LoseSfx;
    public void EatSf()
    {
        EatSfx.Play();
    }

    public void TadaSf()
    {
        TadaSfx.Play();
    }

    public void MeowSf()
    {
        MeowSfx.Play();
    }
    
    public void LoseSf()
    {
        LoseSfx.Play();
    }
}
