using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateMascot : MonoBehaviour
{
    public GameObject[] CharMascot;
    public CharacterManager CharManager;
    public int CMHolder;
    bool getRef;
    public Transform spawnPoint;
    public Move3d PMRef;
    
    void Update()
    {
        CMHolder = CharManager.sa;
        InstantiateCharacter();
        getRef = true;
    }

    void InstantiateCharacter()
    {
        if (getRef == false)
        {
            GameObject mascot = Instantiate(CharMascot[CMHolder], spawnPoint);
            mascot.transform.parent = this.transform;
            PMRef.PlayerMascotRef = mascot;
        }
    }
}
