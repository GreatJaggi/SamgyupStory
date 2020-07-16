using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SatisfactionBar : MonoBehaviour
{
    public float goal;
    public float gauge;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = gauge;
    }

    public void CheckGoal()
    {
        if (slider.value == goal)
        {
            print("Level Completed!");
            GameManager.instance.LevelCompleted();
        }


        else if (GameObject.FindGameObjectsWithTag("Food").Length == 1)
        {
            // this means there's only 1 food to eat if not completed level failed
            print("Level Failed)");
            GameManager.instance.LevelFailed();
        }
            
    }
}
