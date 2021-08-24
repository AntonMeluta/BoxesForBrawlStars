using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementsBrawlersOpened : AchievementsInfo
{
    public BoxesContainer boxesContainer;
    //public PlayerAttributes playerAttributes;
    public StorageFighters storageFighters;

    public TypeBrawler typeBrawler;

    protected override void Awake()
    {
        base.Awake();
        Events.achievmentsBrawlersProgressCheck += OnEnableWithDelay;
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

        for (int i = 0; i < storageFighters.collectionBrawlers.Length; i++)
        {
            interimGetValue = 
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers > storageFighters.collectionBrawlers.Length - 1)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / (storageFighters.collectionBrawlers.Length - 1);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }

    //STANDART
    void CheckAllStandartBrawlers()
    {
        int indexStandartBorderHighIndex = 11;

        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = 0; i < indexStandartBorderHighIndex; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= indexStandartBorderHighIndex - 1)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / (indexStandartBorderHighIndex - 1);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }


    //RARE
    void CheckAllRareBrawlers()
    {
        int indexRaretBorderLowIndex = 11;
        int indexRareBorderHighIndex = 15;
        int indexDifference = indexRareBorderHighIndex - indexRaretBorderLowIndex;

        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = indexRaretBorderLowIndex; i < indexRareBorderHighIndex; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= indexDifference)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / indexDifference;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }

    //ULTRA_RARE
    void CheckAllUltraRareBrawlers()
    {
        int indexUltraRaretBorderLowIndex = 15;
        int indexUltraRareBorderHighIndex = 20;
        int indexDifference = indexUltraRareBorderHighIndex - indexUltraRaretBorderLowIndex;

        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = indexUltraRaretBorderLowIndex; i < indexUltraRareBorderHighIndex; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }

        if (incrementALlBrawlers >= indexDifference)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / indexDifference;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }
    }

    //EPIC
    void CheckAllEpicBrawlers()
    {
        int indexEpicBorderLowIndex = 20;
        int indexEpicBorderHighIndex = 26;
        int indexDifference = indexEpicBorderHighIndex - indexEpicBorderLowIndex;

        int incrementALlBrawlers = 0;
        int interimGetValue = 0;
        
        for (int i = indexEpicBorderLowIndex; i < indexEpicBorderHighIndex; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }

        if (incrementALlBrawlers >= indexDifference)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / indexDifference;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }


    //mythical
    void CheckAllMythicalBrawlers()
    {
        int indexMythBorderLowIndex = 26;
        int indexMythBorderHighIndex = 32;
        int indexDifference = indexMythBorderHighIndex - indexMythBorderLowIndex;

        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = indexMythBorderLowIndex; i < indexMythBorderHighIndex; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }

        if (incrementALlBrawlers >= indexDifference)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / indexDifference;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }
    }


    //LEGEND
    void CheckAllLegendBrawlers()
    {
        int indexLegendBorderLowIndex = 32;
        int indexDifference = storageFighters.collectionBrawlers.Length - indexLegendBorderLowIndex;
        
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = indexLegendBorderLowIndex; i < storageFighters.collectionBrawlers.Length; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }

        if (incrementALlBrawlers >= indexDifference)
        {
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";            
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / indexDifference;
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }
    }
}
