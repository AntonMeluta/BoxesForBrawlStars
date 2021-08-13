using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AchievementsBrawlersOpened : MonoBehaviour
{
    public BoxesContainer boxesContainer;
    public GameManager gameManager;
    public ResourcesConteiner resourcesConteiner;
    public TypeBrawler typeBrawler;

    public Slider slider;
    public Text textSlider;
    int valueForSLider;

    int goToTarget;
    public int rewaredCoin = 10000;
    public int rewaredGem = 1500;

   

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




        switch (typeBrawler)
        {
            case TypeBrawler.allBrawler:
                CheckAllBrawlerOpening();
                break;
            case TypeBrawler.standart:
                CheckAllStandartBrawlers();
                break;
            case TypeBrawler.rare:
                CheckAllRareBrawlers();
                break;
            case TypeBrawler.ultrarare:
                CheckAllUltraRareBrawlers();
                break;
            case TypeBrawler.epic:
                CheckAllEpicBrawlers();
                break;
            case TypeBrawler.mythical:
                CheckAllMythicalBrawlers();
                break;
            case TypeBrawler.legend:
                CheckAllLegendBrawlers();
                break;
            default:
                break;
        }
    }

    //ALL
    void CheckAllBrawlerOpening()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 1; i < gameManager.containerNamesBrawlersInString.Length; i++)
        {
            interimGetValue = 
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= gameManager.containerNamesBrawlersInString.Length - 1)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / (gameManager.containerNamesBrawlersInString.Length - 1);
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }

    //STANDART
    void CheckAllStandartBrawlers()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 1; i < 12; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= 11)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / 11;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }


    //RARE
    void CheckAllRareBrawlers()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 12; i < 16; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= 4)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / 4;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }



    //ULTRA_RARE
    void CheckAllUltraRareBrawlers()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 16; i < 21; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= 5)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / 5;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }



    //EPIC
    void CheckAllEpicBrawlers()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 21; i < 27; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= 6)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / 6;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }


    //mythical
    void CheckAllMythicalBrawlers()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 27; i < 33; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= 6)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / 6;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }


    //LEGEND
    void CheckAllLegendBrawlers()
    {
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        for (int i = 33; i < gameManager.containerNamesBrawlersInString.Length; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= 6)
        {
            PlayerPrefs.SetInt("dsaw" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / 6;
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }



}
