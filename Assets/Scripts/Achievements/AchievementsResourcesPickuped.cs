using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsResourcesPickuped : AchievementsInfo
{
    public TargetPickupedResourcesEnum targetPickupedResourcesEnum;
    public int needCoutResources = 1000;

    protected override void Awake()
    {
        base.Awake();
        Events.achievmentsResProgressCheck += OnEnableWithDelay;
    }

    private void OnEnable()
    {
        Invoke("OnEnableWithDelay", 0.05f);
    }

    void OnEnableWithDelay()
    {
        goToTarget = PlayerPrefs.GetInt("sliderOpened" + gameObject.name, 0);
        if (goToTarget == 1)
        {
            slider.value = 100;
            textSlider.text = slider.value + "%";
            return;
        }

        switch (targetPickupedResourcesEnum)
        {
            case TargetPickupedResourcesEnum.toPickupGem:
                CheckToProgressPickupGem();
                break;
            case TargetPickupedResourcesEnum.toPickupCoin:
                CheckToProgressPickupCoin();
                break;
            case TargetPickupedResourcesEnum.toPickupTicket:
                CheckToProgressPickupTicket();
                break;
            default:
                break;
        }
    }

    void CheckToProgressPickupGem()
    {
        if (needCoutResources <= resourcesConteiner.gems)
        {
            Events.achievmentsResProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);    
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.gems / needCoutResources;
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";
    }


    void CheckToProgressPickupCoin()
    {
        if (needCoutResources <= resourcesConteiner.coins)
        {
            Events.achievmentsResProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddCoins(rewaredCoin, WhatIsResourcesGet.gems, rewaredGem);
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.coins / needCoutResources;
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";
    }


    void CheckToProgressPickupTicket()
    {
        if (needCoutResources <= resourcesConteiner.tickets)
        {
            Events.achievmentsResProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddTickets(rewaredCoin, WhatIsResourcesGet.gems, rewaredGem);
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.tickets / needCoutResources;
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";
    }

}
