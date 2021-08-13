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
    int valueForSLider;

    int goToTarget;
    public int needCoutResources = 1000;
    public int rewaredCoin = 10000;
    public int rewaredGem = 1500;

    private void Awake()
    {
        //slider = GetComponentInParent<Slider>();
    }

    private void OnEnable()
    {
        Invoke("EnableMain", 0.05f);


    }

    void EnableMain()
    {
        goToTarget = PlayerPrefs.GetInt("dsaw" + gameObject.name, 0);
        print("gameObject.name = " + gameObject.name);
        print("goToTarget = " + goToTarget);
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
        print("CheckToProgressPickupGem");
        if (needCoutResources <= resourcesConteiner.gems)
        {
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            print("needCoutResources >= resourcesConteiner.gems");
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.gems / needCoutResources;
        print("newValueSlider = " + newValueSlider);
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";


    }


    void CheckToProgressPickupCoin()
    {
        print("CheckToProgressPickupCoin");
        if (needCoutResources <= resourcesConteiner.coins)
        {
            resourcesConteiner.AddCoins(rewaredCoin, WhatIsResourcesGet.gems, rewaredGem);
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.coins / needCoutResources;
        print("newValueSlider = " + newValueSlider);
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";
    }


    void CheckToProgressPickupTicket()
    {
        print("CheckToProgressPickupTicket");
        if (needCoutResources <= resourcesConteiner.tickets)
        {
            resourcesConteiner.AddTickets(rewaredCoin, WhatIsResourcesGet.gems, rewaredGem);
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            return;
        }

        int newValueSlider = 100 * resourcesConteiner.tickets / needCoutResources;
        print("newValueSlider = " + newValueSlider);
        slider.value = newValueSlider;
        textSlider.text = slider.value + "%";
    }

}
