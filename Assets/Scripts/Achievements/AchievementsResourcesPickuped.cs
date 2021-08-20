using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsResourcesPickuped : MonoBehaviour
{
    public ResourcesConteiner resourcesConteiner;
    public TargetPickupedResourcesEnum targetPickupedResourcesEnum;

    public Slider slider;
    public Text textSlider;

    int goToTarget;
    public int needCoutResources = 1000;
    public int rewaredCoin = 10000;
    public int rewaredGem = 1500;

    public AchievementsGetControl achievementsGetControl;

    string congratulationString;

    private void Awake()
    {
        LocalLang localLang = GetComponentInChildren<LocalLang>();

        if (Application.systemLanguage == SystemLanguage.Russian)
            congratulationString = "Достижение \"" + localLang.RUS + "\" получено";
        else
            congratulationString = "Achievement \"" + localLang.ENG + "\" received";

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
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsResProgressCheck -= OnEnableWithDelay;
            achievementsGetControl.AddLine(congratulationString);
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
            resourcesConteiner.AddCoins(rewaredCoin, WhatIsResourcesGet.gems, rewaredGem);
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsResProgressCheck -= OnEnableWithDelay;
            achievementsGetControl.AddLine(congratulationString);
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
            resourcesConteiner.AddTickets(rewaredCoin, WhatIsResourcesGet.gems, rewaredGem);
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsResProgressCheck -= OnEnableWithDelay;
            achievementsGetControl.AddLine(congratulationString);
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.tickets / needCoutResources;
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";
    }

}
