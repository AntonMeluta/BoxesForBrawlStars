using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsChestsOpened : MonoBehaviour
{
    int goToTarget;
    public ResourcesConteiner resourcesConteiner;
    public int indexChestStatus = 0;
    public int needCountOpeningAction = 100;
    public Slider slider;
    public Text textSlider;

    public int rewaredCoin = 10000;
    public int rewaredGem = 300;

    public AchievementsGetControl achievementsGetControl;

    string congratulationString;

    private void Awake()
    {
        LocalLang localLang = GetComponentInChildren<LocalLang>();

        if (Application.systemLanguage == SystemLanguage.Russian)
            congratulationString = "Достижение \"" + localLang.RUS + "\" получено";
        else
            congratulationString = "Achievement \"" + localLang.ENG + "\" received";

        Events.achievmentsChestProgressCheck += OnEnableWithDelay;
    }

    private void OnEnable()
    {
        Invoke("OnEnableWithDelay", 0.05f);
    }

    void OnEnableWithDelay()
    {
        goToTarget = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_CHEST_TYPE + indexChestStatus, 0);
        
        if (goToTarget == 1)
        {
            slider.value = 100;
            textSlider.text = slider.value + "%";
            return;
        }
        
        CheckProgresshest();
    }

    void CheckProgresshest()
    {
        int howMuchOpened = PlayerPrefs.GetInt
            (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + indexChestStatus, 0);

        if (howMuchOpened >= needCountOpeningAction)
        {
            slider.value = 100;
            textSlider.text = slider.value + "%";
            PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_CHEST_TYPE + indexChestStatus, 1);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
            Events.achievmentsChestProgressCheck -= OnEnableWithDelay;
            achievementsGetControl.AddLine(congratulationString);
        }
        else
        {
            int newValueSlider = 100 * howMuchOpened / needCountOpeningAction;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }
    }

}
