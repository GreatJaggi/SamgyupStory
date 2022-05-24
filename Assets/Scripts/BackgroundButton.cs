using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundButton : MonoBehaviour
{
    public GameObject[] bg;
    public int no;
    
    
 
    void Update()
    {
        bg[no].gameObject.SetActive(true);
    }

    public void bgButton(int bt)
    {
        for(int x = 0; x < bg.Length; x++)
        {

            if(x == bt)
            {
                bg[x].gameObject.SetActive(true);
                no = x;
            }
            else
            {
                bg[x].gameObject.SetActive(false);
            }
           
        }

<<<<<<< HEAD
=======
        
>>>>>>> 242ac70189bfcd5c0bfffedc6c0271749497af59
    }

}
