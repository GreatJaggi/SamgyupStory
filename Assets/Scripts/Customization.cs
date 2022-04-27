using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    //Buttons
    public GameObject CButtonS;
    public GameObject BButtonS;
    public GameObject GButtonS;
    public GameObject CSButtonS;

    //Sets
    public GameObject PlayerSet;
    public GameObject GrillSet;
    public GameObject ChopstickSet;
    void Start()
    {
        CButtonS.SetActive(true);
        PlayerSet.SetActive(true);
        BButtonS.SetActive(false);
        GButtonS.SetActive(false);
        GrillSet.SetActive(false);
        CSButtonS.SetActive(false);
        ChopstickSet.SetActive(false);
    }

    public void CButton()
    {
        CButtonS.SetActive(true);
        PlayerSet.SetActive(true);
        BButtonS.SetActive(false);
        GButtonS.SetActive(false);
        GrillSet.SetActive(false);
        CSButtonS.SetActive(false);
        ChopstickSet.SetActive(false);
    }

    public void BButton()
    {
        CButtonS.SetActive(false);
        BButtonS.SetActive(true);
        GButtonS.SetActive(false);
        CSButtonS.SetActive(false);
        //ChopstickSet.SetActive(false);
    }

    public void GButton()
    {
        CButtonS.SetActive(false);
        PlayerSet.SetActive(false);
        BButtonS.SetActive(false);
        GButtonS.SetActive(true);
        GrillSet.SetActive(true);
        CSButtonS.SetActive(false);
        ChopstickSet.SetActive(false);
    }

    public void CSButton()
    {
        CButtonS.SetActive(false);
        PlayerSet.SetActive(false);
        BButtonS.SetActive(false);
        GButtonS.SetActive(false);
        GrillSet.SetActive(false);
        CSButtonS.SetActive(true);
        ChopstickSet.SetActive(true);
    }
}
