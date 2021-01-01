using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton instance;
    private void Awake() {
        if(AudioSingleton.instance == null) AudioSingleton.instance = this;
        else Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
