using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect_Rating : MonoBehaviour
{
    public GameObject[] ratings;

    public int levelIndex;
    public int rating;

    private void Awake()
    {
        SetRating();
    }

    private void OnEnable()
    {
        SetRating();
    }

    void SetRating()
    {
        rating = ES3.Load("Rating_LevelIndex_" + levelIndex, 0);

        for (int i = 0; i < ratings.Length; i++)
            ratings[i].gameObject.SetActive(false);

        for(int i = 0; i < rating; i++)
            ratings[i].gameObject.SetActive(true);
    }
}
