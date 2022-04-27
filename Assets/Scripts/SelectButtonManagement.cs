using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonManagement : MonoBehaviour
{
    public GameObject[] buttons;

    void Start()
    {

    }
    public void buttonP(int bp)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == bp)
            {
               buttons[i].gameObject.SetActive(true);
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
