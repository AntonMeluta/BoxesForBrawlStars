using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StartApp;
using System;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour{

    //rateUs
    int isRateUS;
    public GameObject rateUsObj;    
    public string rateUsRef;

    int toPrmReqst = 0;
    string getString = "";

    public delegate void VideoFinished();
    public VideoFinished plasticDelegate;
    ShowOptions optUnitAds;

    //public int howOften = 20;
    public GameObject gdprConsentScreen;

    //startapp
    bool startappIntersitialState;
    bool startappRewaredState;
    InterstitialAd adsIntersitialStartapp;
    InterstitialAd adsRewaredStartapp;

    
    //privacy
    public string privacyRef;

    //GPDR
    int isShowedGdprPanelInt;
    SystemLanguage systemLanguage;


    private void Awake()
    {

        optUnitAds = new ShowOptions { resultCallback = ListenerRewaredUnity };

        isShowedGdprPanelInt = PlayerPrefs.GetInt("isShowedGdprPanelInt", 0);
        systemLanguage = Application.systemLanguage;        
        if (isShowedGdprPanelInt == 0)
        {
            if (systemLanguage == SystemLanguage.Russian || systemLanguage == SystemLanguage.Chinese ||
            systemLanguage == SystemLanguage.ChineseSimplified || systemLanguage == SystemLanguage.ChineseSimplified ||
            systemLanguage == SystemLanguage.Japanese || systemLanguage == SystemLanguage.Thai ||
            systemLanguage == SystemLanguage.Vietnamese || systemLanguage == SystemLanguage.Ukrainian ||
            systemLanguage == SystemLanguage.Afrikaans || systemLanguage == SystemLanguage.Arabic ||
            systemLanguage == SystemLanguage.Belarusian || systemLanguage == SystemLanguage.Indonesian ||
            systemLanguage == SystemLanguage.Korean || systemLanguage == SystemLanguage.Unknown)
            {
                isShowedGdprPanelInt = 1;
                PlayerPrefs.SetInt("isShowedGdprPanelInt", isShowedGdprPanelInt);
                TapConsent(true);
                return;
            }
            gdprConsentScreen.SetActive(true);
        }
        else
        {
            TapConsent(true);
        }
            
        
    }

    public void UserAgreeGdpr()
    {
        gdprConsentScreen.SetActive(false);
        isShowedGdprPanelInt = 1;
        PlayerPrefs.SetInt("isShowedGdprPanelInt", isShowedGdprPanelInt);
        TapConsent(true);
    }

    public void UserNOTAgreeGdpr()
    {
        gdprConsentScreen.SetActive(false);
        isShowedGdprPanelInt = 0;
        PlayerPrefs.SetInt("isShowedGdprPanelInt", isShowedGdprPanelInt);
        TapConsent(false);
    }


    public void InvokeRateUsAction()
    {
        isRateUS = PlayerPrefs.GetInt("isRateUS", 0);
        if (isRateUS == 0)
            rateUsObj.SetActive(true);
    }

    public void RateUsHere()
    {
        isRateUS = 1;
        PlayerPrefs.SetInt("isRateUS", isRateUS);
        rateUsObj.SetActive(false);
        Application.OpenURL(rateUsRef);
    }

   
    public void TapConsent(bool consentResultUser)
    {
        toPrmReqst = 0;
        StartCoroutine(RequestForAds());

        //startapp initialieze
        //intersitial init
        adsIntersitialStartapp = AdSdk.Instance.CreateInterstitial();
        adsIntersitialStartapp.RaiseAdLoaded += (sender, e) => {
            startappIntersitialState = true;
        };
        adsIntersitialStartapp.RaiseAdShown += (sender, e) => startappIntersitialState = false;
        adsIntersitialStartapp.RaiseAdClosed += (sender, e) => adsIntersitialStartapp.LoadAd(InterstitialAd.AdType.Automatic);
        adsIntersitialStartapp.RaiseAdLoadingFailed += (sender, e) => {
            startappIntersitialState = false;
        };

        //rewared init
        adsRewaredStartapp = AdSdk.Instance.CreateInterstitial();
        adsRewaredStartapp.RaiseAdLoaded += (sender, e) => {
            startappRewaredState = true;
        };
        adsRewaredStartapp.RaiseAdShown += (sender, e) => startappRewaredState = false;
        adsRewaredStartapp.RaiseAdClosed += (sender, e) => adsRewaredStartapp.LoadAd(InterstitialAd.AdType.Rewarded);
        adsRewaredStartapp.RaiseAdLoadingFailed += (sender, e) => {
            startappRewaredState = false;
        };
        adsRewaredStartapp.RaiseAdVideoCompleted += (sender, e) => {
            plasticDelegate();
        };

        //load ads startapp
        adsIntersitialStartapp.LoadAd(InterstitialAd.AdType.Automatic);
        adsRewaredStartapp.LoadAd(InterstitialAd.AdType.Rewarded);
        AdSdk.Instance.SetUserConsent("pas", consentResultUser,
        (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds);

        
    }

    IEnumerator RequestForAds()
    {
        
        UnityWebRequest www = UnityWebRequest.Get("http://gamebred.beget.tech/boxforbrawlstars3/bs3forunity");
        yield return www.Send();

        if (www.isNetworkError)
        {
            toPrmReqst = 0;
            Debug.Log("FAILED");
        }
        else
        {
            Debug.Log("USPEH!");
            getString = www.downloadHandler.text;

            var getValues = JSON.Parse(getString);
            toPrmReqst = getValues["requtounity"].AsInt;            
        }

        if (toPrmReqst == 2)
            LoopUnity();

    }

    public void LoopUnity()
    {
        InvokeRepeating("VideoSendOut", 15, 15);
    }

    

    public void LoopUnityStop()
    {
        CancelInvoke();
    }
    

    //video
    public void VideoSendOut()
    {
        
        if (toPrmReqst == 2)
        {
            if (Advertisement.IsReady("video"))
                Advertisement.Show("video");
            else if (startappIntersitialState)
                adsIntersitialStartapp.ShowAd();

            return;
        }


        if (toPrmReqst == 3)
        {
            if (startappIntersitialState)
                adsIntersitialStartapp.ShowAd();

        }        

    }

    //rewared video
    public void VideoRewSendOut()
    {
        if (toPrmReqst == 2)
        {
            if (Advertisement.IsReady("rewardedVideo"))
                Advertisement.Show("rewardedVideo", optUnitAds);            
            else if (startappRewaredState)
                adsRewaredStartapp.ShowAd();

            return;
        }


        if (toPrmReqst == 1 || toPrmReqst == 3)
        {
            if (startappRewaredState)
                adsRewaredStartapp.ShowAd();

        }

    }

    public void PrivacyTransitionGo()
    {
        Application.OpenURL(privacyRef);
    }


    void ListenerRewaredUnity(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                plasticDelegate();
                break;
            case ShowResult.Skipped:
                print("ShowResult.Skipped");
                break;
            default:
                break;
        }
    }

}
