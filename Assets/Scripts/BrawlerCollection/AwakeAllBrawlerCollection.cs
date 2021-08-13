using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeAllBrawlerCollection : MonoBehaviour
{

   

    Button button;
    Sprite fullBrawlerSprite;
    public SliderParametresBrawler sliderParametresBrawler;

    public GameManager gameManager;
    public int indexBrawler;
    string getName;
    public BrawlerInfo brawlerInfo;
    public GameObject lockSection;


    string infoBrawlers;
    SystemLanguage systemLanguage;
    public string RUS;
    public string EN;

    public int valueAttack = 3;
    public int valueHealth = 4;
    public int valueSuper = 2;



    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PressBrawlerButton);
        getName = gameManager.containerNamesBrawlersInString[indexBrawler];

        systemLanguage = Application.systemLanguage;
        if (systemLanguage == SystemLanguage.Russian)
            infoBrawlers = RUS;
        else
            infoBrawlers = EN;

        fullBrawlerSprite = gameManager.conteinerSpritesBrawlersAll[indexBrawler];

    }


    private void OnEnable()
    {
        int permissionINdex =
            PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + indexBrawler, 0);
        if (permissionINdex == 0)
        {
            button.interactable = false;
            lockSection.SetActive(true);
        }
        else
        {
            button.interactable = true;
            lockSection.SetActive(false);
        }


    }


    public void PressBrawlerButton()
    {
        brawlerInfo.GetInfoAboutNeedBrawler(getName, infoBrawlers, fullBrawlerSprite);
        brawlerInfo.gameObject.SetActive(true);
        sliderParametresBrawler.GetValues(valueAttack, valueHealth, valueSuper);

    }

}
