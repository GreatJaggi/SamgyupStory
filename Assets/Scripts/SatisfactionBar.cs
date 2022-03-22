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
        slider.value = 0;
        GameManager.instance.rating = 0;
        Cat.instance.satisfaction = 0;

        slider.maxValue = goal;
        goalBar.maxValue = slider.maxValue;
        goalBar.value = goal;

        /*
        // Partitioned Value Slider / Goal
        goalBar.maxValue = slider.maxValue;
        goalBar.value = goal;
        */
    }

    public void CheckGoal()
    {
        if (slider.value >= goal)
        {
            GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
            foreach(GameObject food in foods)
            {
                food.GetComponent<Food>().StopAllCoroutines();
                //food.GetComponent<Food>().isCooking = false;
            }

            print("Level Finish! Satisfied!");

            GameManager.instance.SetRating(3);

            GameManager.instance.LevelCompleted();
        }

        else if (GameObject.FindGameObjectsWithTag("Food").Length == 1)
        {
            print("Level Finish! Nice Try!");

            // Formula: r = v / ( g / 3 )
            Debug.LogError((int)Mathf.Floor(slider.value / (goal / 3)));
            GameManager.instance.SetRating((int)Mathf.Floor(slider.value / (goal / 3)));

            GameManager.instance.LevelCompleted();
        }
    }
}
