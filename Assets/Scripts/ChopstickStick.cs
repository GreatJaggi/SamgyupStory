using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickStick : MonoBehaviour
{
    public GameObject[] CSticks;
    public int noS;
    public ObjectSelection oss;

    void Update()
    {
        Debug.Log("WorkingButton");
        CSticks[noS].gameObject.SetActive(true);
        if (oss != null)
        {
            oss.characterIndex = noS;
        }
    }
    public void CSButton(int cs)
    {
        for (int x = 0; x < CSticks.Length; x++)
        {
            if (x == cs)
            {
                CSticks[x].gameObject.SetActive(true);
                noS = x;
            }
            else
            {
                CSticks[x].gameObject.SetActive(false);
            }

        }


    }
}
