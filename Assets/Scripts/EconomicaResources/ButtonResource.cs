using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonResource : MonoBehaviour
{
    AudioController audioController;
    UnityAds unityAds;
    Button button;
    ResourcesConteiner resourcesConteiner;

    public ResourcesButton resourcesButton;

    public int currentDelta;
    public WhatIsResourcesGet currentWhatIsResourcesGet;
    public int currentDeltaNewResource;

    public bool isAdsButton = false;


    private void Awake()
    {
        button = GetComponent<Button>();
        

        switch (resourcesButton)
        {
            case ResourcesButton.coin:
                button.onClick.AddListener(ActionButtonCoin);
                break;
            case ResourcesButton.gem:
                button.onClick.AddListener(ActionButtonGem);
                break;
            case ResourcesButton.ticket:
                button.onClick.AddListener(ActionButtonTicket);
                break;
            default:
                break;
        }

    }
    private void Start()
    {
        resourcesConteiner = GameObject.FindObjectOfType<ResourcesConteiner>();
        unityAds = GameObject.FindObjectOfType<UnityAds>();
        audioController = GameObject.FindObjectOfType<AudioController>();
    }



    public void ActionButtonCoin ()
    {
        if(isAdsButton)
        {
            unityAds.plasticDelegate = AdsCoinGet;
            unityAds.VideoRewSendOut();
            return;
        }

        resourcesConteiner.AddCoins(currentDelta, currentWhatIsResourcesGet, currentDeltaNewResource);
        
    }

    public void ActionButtonGem()
    {
        if (isAdsButton)
        {
            unityAds.plasticDelegate = AdsGetGem;
            unityAds.VideoRewSendOut();
            return;
        }

        resourcesConteiner.AddGems(currentDelta, currentWhatIsResourcesGet, currentDeltaNewResource);
        
    }

    public void ActionButtonTicket()
    {
        resourcesConteiner.AddTickets(currentDelta, currentWhatIsResourcesGet, currentDeltaNewResource);
        
    }




    public void AdsCoinGet()
    {
        resourcesConteiner.AddCoins(currentDelta, currentWhatIsResourcesGet, currentDeltaNewResource);

    }

    public void AdsGetGem()
    {
        resourcesConteiner.AddGems(currentDelta, currentWhatIsResourcesGet, currentDeltaNewResource);
    }





}
