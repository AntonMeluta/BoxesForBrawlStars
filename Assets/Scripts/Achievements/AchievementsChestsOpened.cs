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


    private void OnEnable()
    {
        Invoke("EnableMain", 0.05f);


    }

    void EnableMain()
    {
        goToTarget = PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_CHEST_TYPE + indexChestStatus, 0);
        print("gameObject.name = " + gameObject.name);
        print("goToTarget = " + goToTarget);
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
            (GameManager.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + indexChestStatus, 0);

        if (howMuchOpened >= needCountOpeningAction)
        {
            slider.value = 100;
            textSlider.text = slider.value + "%";
            PlayerPrefs.SetInt(GameManager.PLAYER_PREFS_KEY_CHEST_TYPE + indexChestStatus, 1);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * howMuchOpened / needCountOpeningAction;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }
    }

}
