using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill_Cuztomizer : MonoBehaviour
{

    public GameObject[] Grills;
    public int noG;
    public ObjectSelection os;

    void Update()
    {
        Debug.Log("WorkingButton");
        Grills[noG].gameObject.SetActive(true);
        if (os != null)
        {
            os.characterIndex = noG;
        }
    }
    public void GrButton(int gt)
    {
        for (int x = 0; x < Grills.Length; x++)
        {
            if (x == gt)
            {
                Grills[x].gameObject.SetActive(true);
                noG = x;
            }
            else
            {
                Grills[x].gameObject.SetActive(false);
            }
            
        }

        
    }
}
