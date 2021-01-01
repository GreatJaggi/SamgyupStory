using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject satisfactionBar;

    private void Awake()
    {
        int ratingSum = 0;
        for(int i = 0; i < levels.Length; i++)
            ratingSum += (int)ES3.Load("Rating_LevelIndex_" + i, 0);

        ES3.Save("Rating_Total", ratingSum);
    }

    public void SetLevel(int levelIndex)
    {
        satisfactionBar.GetComponent<SatisfactionBar>().goal = levels[levelIndex].GetComponent<LevelInformation>().GetGoal();
        //levels[levelIndex].transform.DetachChildren();

        GameManager.instance.currentLevelIndex = levelIndex;

        GameObject clone = GameObject.Instantiate(levels[levelIndex]);
        clone.transform.DetachChildren();
        Destroy(clone);
    }

    public void SetLevelFromCurrentIndex()
    {
        SetLevel(GameManager.instance.currentLevelIndex);
    }

    public void ReplayScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadShop()  {
        SceneManager.LoadScene(1);
    }
}
