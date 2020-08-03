using UnityEngine;

public class LevelInformation : MonoBehaviour
{
    public int levelIndex;
    public float goal;
    public float gauge;

    public int rating;

    private void Awake()
    {
        rating = ES3.Load("Rating_LevelIndex_" + levelIndex, 0);
    }

    public void SetRating(int value)
    {
        rating = value;
        ES3.Save("Rating_LevelIndex_" + levelIndex, rating);
    }

    public int GetRating()
    {
        return rating;
    }

    public float GetGoal()
    {
        return goal;
    }

    public float GetGauge()
    {
        return gauge;
    }
}
