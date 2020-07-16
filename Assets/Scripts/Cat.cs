﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    #region Singleton
    public static Cat instance;
    private void Awake()
    {
        if (Cat.instance == null)
            Cat.instance = this;
        else Destroy(Cat.instance);
    }
    #endregion

    public float satisfaction;

    public void SetSatisfaction(float value)
    {
        satisfaction = value;
    }

    public void AddSatisfaction(float value)
    {
        satisfaction += value;
        Debug.Log(string.Format("Added {0} to Satisfaction", value));
    }

    public float GetSatisfaction()
    {
        return satisfaction;
    }
    
}
