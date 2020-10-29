
using UnityEngine;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    public Text message;
    public Text levelInfo;
    public GameObject[] starRating;
    
    private void OnEnable()
    {
        ResetLevel();
    }

    public void ResetLevel()    {
        PopulateUI();
        CleanStage();
    }

    void PopulateUI()
    {
        message.text = GameManager.instance.GenerateSatisfactionMessage();
        levelInfo.text = "Level " + GameManager.instance.currentLevelIndex + 1;

        for (int i = 0; i < 3; i++)
            starRating[i].SetActive(false);

        for (int i = 0; i < GameManager.instance.rating; i++)
        {
            print("index: " + i);
            starRating[i].SetActive(true);
        }
    }

    void CleanStage()
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
        GameObject[] dishwares = GameObject.FindGameObjectsWithTag("Dishware");
        foreach (GameObject food in foods)
            Destroy(food);
            
        foreach(GameObject dishware in dishwares) 
            Destroy(dishware);
    }
}
