
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public int unlockValue = 0;
    void OnEnable()
    {
        print("Enabled!!!");
        this.GetComponent<Button>().interactable = (int)ES3.Load("Rating_Total", 0) >= unlockValue;
    }
}
