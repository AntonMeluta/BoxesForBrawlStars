using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsChestsOpened : AchievementsInfo
{
    public int indexChestStatus = 0;
    public int needCountOpeningAction = 100;

    protected override void Awake()
    {
        base.Awake();
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
            Events.achievmentsChestProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_CHEST_TYPE + indexChestStatus, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";                                
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * howMuchOpened / needCountOpeningAction;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }
    }

}
