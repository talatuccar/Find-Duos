using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ads_Manage : MonoBehaviour
{

#if UNITY_EDITOR
    string _adUnitID = "ca-app-pub-6432807667712153/8468101625";
#else
        string _adUnitID = "unused";
#endif

    InterstitialAd Ad_Transt;

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {

        });
        DontDestroyOnLoad(this);
    }

    public void Make_Adv()
    {
        if (Ad_Transt != null)
        {
            Ad_Transt.Destroy();
            Ad_Transt = null;
        }

        var _AdRequest = new AdRequest.Builder();

        InterstitialAd.Load(_adUnitID, _AdRequest.Build(),
            (InterstitialAd Ad, LoadAdError error) =>
            {
                if (error != null || Ad == null)
                {

                    
                    return;
                }

                Ad_Transt = Ad;

            });

       Check_Adv(Ad_Transt);
    }


    public void Check_Adv(InterstitialAd ad)
    {
       
        ad.OnAdFullScreenContentClosed += () =>
        {
            
            Make_Adv();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
           
            Make_Adv();
        };
    }

    public void Show_Adv()
    {

        if (Ad_Transt != null && Ad_Transt.CanShowAd())
        {
            Ad_Transt.Show();
            
        }
       
    }
}
