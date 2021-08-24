using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AchievementsInfo : MonoBehaviour
{
    public ResourcesConteiner resourcesConteiner;    

    public Slider slider;
    public Text textSlider;

    protected int goToTarget;
    
    public int rewaredCoin = 10000;
    public int rewaredGem = 1500;

    public AchievementsGetControl achievementsGetControl;

    protected string congratulationString;

    protected virtual void Awake()
    {
        LocalLang localLang = GetComponentInChildren<LocalLang>();

        if (Application.systemLanguage == SystemLanguage.Russian)
            congratulationString = "Достижение \"" + localLang.RUS + "\" получено";
        else
            congratulationString = "Achievement \"" + localLang.ENG + "\" received";

        print("Awake Achievements...");
    }

}
