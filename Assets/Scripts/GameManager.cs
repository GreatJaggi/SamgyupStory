using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    public UnityEvent levelCompleteEvent;

    public GameObject levelCompleteWindow;
    // public GameObject levelFailedWindow;

    public int rating;
    public string satisfactionMessage;

    public int currentLevelIndex;
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

    public void LevelSelect()
    {
        // mainCamAnim.SetBool("LevelSelection", true);
    }

    public void MainMenu()
    {
        mainCamAnim.SetBool("LevelSelection", false);
    }

    // public void LevelFailed()
    // {
    //     levelFailedWindow.SetActive(true);
    // }

    public void LevelCompleted()
    {
        levelCompleteEvent.Invoke();
    }

    public void SetRating(int value)
    {
        print("SETTING: " + value + " >= " + (int)ES3.Load("Rating_LevelIndex_" + currentLevelIndex, 0));
        if (value >= (int)ES3.Load("Rating_LevelIndex_" + currentLevelIndex, 0))
        {
            rating = value;
            ES3.Save("Rating_LevelIndex_" + currentLevelIndex, rating);
        }
            
    }

    public string GenerateSatisfactionMessage()
    {
        switch(rating)
        {
            case 1:
                switch(Random.Range(0, 3))
                {
                    case 0: return "Aww! I want to eat more!";
                    case 1: return "Not enough!";
                    case 2: return "So hungry!";
                }
                break;
            case 2:
                switch (Random.Range(0, 3))
                {
                    case 0: return "Thanks for the food!";
                    case 1: return "Almost good where is the dessert?";
                    case 2: return "Okay I want more!";
                }
                break;
            case 3:
                switch (Random.Range(0, 3))
                {
                    case 0: return "That was delicious!";
                    case 1: return "I love the food! Purrfect!";
                    case 2: return "Sooo satisfied!";
                }
                break;
            default: return "I hate it!";
        }

        return "Error!";
    }
}