using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHUD : MonoBehaviour
{
    public GameObject[] IHList;

    public int d;
    public GameObject ImageButton;
    void Update()
    {
        Display(d);
    }

    public void Display(int dis)
    {
        for(int x = 0; x < IHList.Length; x++)
        {
            if(x == dis)
            {
                IHList[x].SetActive(true);
            }
            else
            {
                IHList[x].SetActive(false);
            }
        }
    }

    public void RemoveImage()
    {
        ImageButton.SetActive(false);
    }
}
