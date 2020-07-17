using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;

    public void SetLevel(int levelIndex)
    {
        GameObject.Find("Satisfaction Bar").GetComponent<SatisfactionBar>().goal = levels[levelIndex].GetComponent<LevelInformation>().GetGoal();
        levels[levelIndex].transform.DetachChildren();
    }

    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
