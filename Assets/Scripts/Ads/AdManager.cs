using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdManager : MonoBehaviour
{
    public static AdManager Instance;
    private void Awake() {
        if(Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    private void Start() {
        Advertisements.Instance.Initialize();

        Advertisements.Instance.ShowBanner(BannerPosition.BOTTOM, BannerType.SmartBanner);
    }

    public void ShowInterstitial() {
        Advertisements.Instance.ShowInterstitial();
    }
}
