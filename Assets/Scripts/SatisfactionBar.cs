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


    public Slider goalBar;
    public void SetGoalBar()
    {
        goalBar.maxValue = slider.maxValue;
        goalBar.value = goal;
    }

    public void CheckGoal()
    {
        if (slider.value >= goal)
        {
            print("Level Completed!");
            GameManager.instance.LevelCompleted();
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
            foreach(GameObject food in foods)
            {
                food.GetComponent<Food>().StopAllCoroutines();
                //food.GetComponent<Food>().isCooking = false;
            }
        }

        else if (GameObject.FindGameObjectsWithTag("Food").Length == 1)
        {
            // this means there's only 1 food to eat if not completed level failed
            print("Level Failed)");
            GameManager.instance.LevelFailed();
        }
            
    }
}
