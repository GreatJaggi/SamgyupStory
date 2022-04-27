using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationHolder : MonoBehaviour
{
    //Background
    private string backgroundIndexs = "bgt";
    public int backgroundIndex;
    public BackgroundButton background;
    private string keyName = "selectedCharacterIndex";

    //Grill
    private string grillIndexs = "glt";
    public int grillIndex;
    public Grill_Cuztomizer grill;

    //Chopstick
    private string chopstickIndexs = "slt";
    public int chopstickIndex;
    public ChopstickStick CStick;


    void Start()
    {
        LoadSelectionBG();
        LoadSelectionGr();
        LoadSelectionCS();
        Debug.Log("Starting");
    }
    //BackgroundEasySave
    public void SaveSelectionBG()
    {
        ES3.Save<int>(backgroundIndexs, background.no);
    }
    public void LoadSelectionBG()
    {

        background.no = ES3.Load<int>(backgroundIndexs);
        //background.bg[background.no].SetActive(true);
        Debug.Log(background.no);
    }

    //GrillEasySave
    public void SaveSelectionGr()
    {
        ES3.Save<int>(grillIndexs, grill.noG);
    }

    public void LoadSelectionGr()
    {
        if(grill != null)
        {
        grill.noG = ES3.Load<int>(grillIndexs);
        }
    }

    //ChopstickEasySave
    public void SaveSelectionCS()
    {
        ES3.Save<int>(chopstickIndexs, CStick.noS);
    }
    public void LoadSelectionCS()
    {
        if(CStick != null)
        {
        CStick.noS = ES3.Load<int>(chopstickIndexs);
        }
    }


}
