using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//NeedFix! убрать магические числа
public class AchievementsBrawlersOpened : MonoBehaviour
{
    public BoxesContainer boxesContainer;
    public PlayerAttributes playerAttributes;
    public ResourcesConteiner resourcesConteiner;
    public TypeBrawler typeBrawler;

    public Slider slider;
    public Text textSlider;

    int goToTarget;
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

        for (int i = 1; i < playerAttributes.containerNamesBrawlersInString.Length; i++)
        {
            interimGetValue = 
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= playerAttributes.containerNamesBrawlersInString.Length - 1)
        {
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
            achievementsGetControl.AddLine(congratulationString);
            resourcesConteiner.AddGems(rewaredGem, WhatIsResourcesGet.coins, rewaredCoin);
        }
        else
        {
            int newValueSlider = 100 * incrementALlBrawlers / (playerAttributes.containerNamesBrawlersInString.Length - 1);
            print("newValueSlider = " + newValueSlider);
            slider.value = newValueSlider;
            textSlider.text = slider.value + "%";
        }

    }

    //STANDART
    void CheckAllStandartBrawlers()
    {
        int indexStandartBorderHighIndex = 12;

        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = 1; i < indexStandartBorderHighIndex; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }


        if (incrementALlBrawlers >= indexStandartBorderHighIndex - 1)
        {
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
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
        int indexRaretBorderLowIndex = 12;
        int indexRareBorderHighIndex = 16;
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
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
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
        int indexUltraRaretBorderLowIndex = 16;
        int indexUltraRareBorderHighIndex = 21;
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
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
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
        int indexEpicBorderLowIndex = 21;
        int indexEpicBorderHighIndex = 27;
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
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
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
        int indexMythBorderLowIndex = 27;
        int indexMythBorderHighIndex = 33;
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
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
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
        int indexLegendBorderLowIndex = 33;
        int indexDifference = playerAttributes.
            containerNamesBrawlersInString.Length - indexLegendBorderLowIndex;
        
        int incrementALlBrawlers = 0;
        int interimGetValue = 0;

        for (int i = indexLegendBorderLowIndex; i < playerAttributes.containerNamesBrawlersInString.Length; i++)
        {
            interimGetValue =
                PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + i, 0);
            if (interimGetValue == 1)
                incrementALlBrawlers++;
        }

        if (incrementALlBrawlers >= indexDifference)
        {
            PlayerPrefs.SetInt("sliderOpened" + gameObject.name, 1);
            slider.value = 100;
            textSlider.text = slider.value + "%";
            Events.achievmentsBrawlersProgressCheck -= OnEnableWithDelay;
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
