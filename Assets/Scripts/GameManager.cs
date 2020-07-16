using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    public GameObject levelCompleteWindow;
    public GameObject levelFailedWindow;
    private void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
        else Destroy(GameManager.instance.gameObject);
    }
    #endregion

    Animator mainCamAnim;

    private void Start()
    {
        mainCamAnim = Camera.main.gameObject.GetComponent<Animator>();
    }

    public void PlayGame()
    {
        mainCamAnim.SetBool("Play", true);
    }

    public void LevelFailed()
    {
        levelFailedWindow.SetActive(true);
    }

    public void LevelCompleted()
    {
        levelCompleteWindow.SetActive(true);
    }
}