using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxesContainer : MonoBehaviour
{
    AudioController audioController;
    bool isPersonDouble = false;
    public bool IsPersonDouble
    {
        get
        {
            return isPersonDouble;
        }
        private set { }
    }     

    int savedIndexBox;
    //public PlayerAttributes playerAttributes;
    public List<BrawlerStats_SO> allBrawlers;
    public DropScreenAll dropScreenAll;
    public DropScreenAll dropsScreenAll_Extra;
    public Image imageBoxesUi;
    public Sprite[] allSpritesBoxes;
    public GameObject BoxesContainerGameObject;
    public ResourcesConteiner resourcesConteiner;

    //resourcesScreen
    public GameObject textObjCoinUi;
    public GameObject textObjGemUi;
    public Text lowTextRewared;
    public Sprite coinImage;
    public Sprite gemImage;
    public Image imageResourceUi;
    public int lowBorderGemAll = 5;
    public int highBorderGemAll = 30;
    public int lowBorderCoinAll = 1;
    public int highBorderCoinAll = 10;

    //DropScreenPerson
    public Image brawlerDropImageRewared;
    public Text brawlerNameDropTextRewared;
    public int lowIndexDropBox1 = 1;
    public int highIndexDropBox1 = 9;
    public int lowIndexDropBox2 = 9;
    public int highIndexDropBox2 = 18;
    public int lowIndexDropBox3 = 18;
    public int highIndexDropBox3 = 29;
    public int lowIndexDropBox4 = 18;
    public int highIndexDropBox4 = 33;
    public int forCoinsChest = 500;
    public int forGemsChest = 300;

    public GameObject[] animatorsBoxes;

    public UnityAds unityAds;

    public GameObject screepPerson;
    public GameObject screepAll;


    private void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();
    }

    public void BoxPressedScreen(int numberBox)
    {
        savedIndexBox = numberBox;
        imageBoxesUi.sprite = allSpritesBoxes[savedIndexBox];        

        if (savedIndexBox == 0)
        {            
            BoxesContainerGameObject.SetActive(true);

            int howMuchOpened0 = PlayerPrefs.GetInt
            (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + savedIndexBox, 0);
            howMuchOpened0++;
            PlayerPrefs.SetInt
                (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + savedIndexBox, howMuchOpened0);
            //NeedFix acheivments check...
            Events.CallAchivmentsChestProgressCheck();
            return;
        }        

        if (savedIndexBox == 1)
        {
            unityAds.plasticDelegate = Open2Chest;
            unityAds.VideoRewSendOut();
            return;
        }           


        if (savedIndexBox == 2)
        {
            int costOpened = 500;

            if (resourcesConteiner.coins >= forCoinsChest)
            {                
                resourcesConteiner.AddCoins(-costOpened);
                BoxesContainerGameObject.SetActive(true);
                int howMuchOpened2 = PlayerPrefs.GetInt
                (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + savedIndexBox, 0);
                howMuchOpened2++;
                PlayerPrefs.SetInt
                    (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + savedIndexBox, howMuchOpened2);
                Events.CallAchivmentsChestProgressCheck();
                return;
            }
        }

        if (savedIndexBox == 3)
        {
            int costOpened = 300;

            if (resourcesConteiner.gems >= forGemsChest)
            {
                resourcesConteiner.AddGems(-costOpened);
                BoxesContainerGameObject.SetActive(true);
                int howMuchOpened3 = PlayerPrefs.GetInt
                (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + savedIndexBox, 0);
                howMuchOpened3++;
                PlayerPrefs.SetInt
                    (PlayerAttributes.PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING + savedIndexBox, howMuchOpened3);
                Events.CallAchivmentsChestProgressCheck();
                return;
            }
        }
    }

    public void Open2Chest()
    {
        //Events.CallAchivmentsChestProgressCheck();
        BoxesContainerGameObject.SetActive(true);
    }

    public void DropScreenResource()
    {
        bool isCoins = Random.Range(0, 2) == 0;
        int revaredRes;
        if (isCoins)
        {
            revaredRes = Random.Range
                (lowBorderCoinAll * (savedIndexBox + 1), highBorderCoinAll * (savedIndexBox + 1));
            print("revaredRes = " + revaredRes);
            resourcesConteiner.AddCoins(revaredRes);
            textObjCoinUi.SetActive(true);
            textObjGemUi.SetActive(false);
            imageResourceUi.sprite = coinImage;

            dropScreenAll.resourceImage.sprite = coinImage;
            dropScreenAll.resourceTextProfit.text = revaredRes.ToString();
            dropsScreenAll_Extra.resourceImage.sprite = coinImage;
            dropsScreenAll_Extra.resourceTextProfit.text = revaredRes.ToString();

            audioController.PlayGetCoins();

        }
        else
        {
            revaredRes = Random.Range
                (lowBorderGemAll * (savedIndexBox + 1), highBorderGemAll * (savedIndexBox + 1));
            print("randRewaredGems = " + revaredRes);
            resourcesConteiner.AddGems(revaredRes);
            textObjCoinUi.SetActive(false);
            textObjGemUi.SetActive(true);
            imageResourceUi.sprite = gemImage;

            dropScreenAll.resourceImage.sprite = gemImage;
            dropScreenAll.resourceTextProfit.text = revaredRes.ToString();
            dropsScreenAll_Extra.resourceImage.sprite = gemImage;
            dropsScreenAll_Extra.resourceTextProfit.text = revaredRes.ToString();

            audioController.PlayGemsGatcha();

        }

        lowTextRewared.text = "x" + revaredRes;
    }



    public void DropScreenPerson()
    {
        int checkPlayerPrefs = 0;

        int randIndexBrawl = 0;
        switch (savedIndexBox)
        {            
            case 0:
                randIndexBrawl = Random.Range(lowIndexDropBox1, highIndexDropBox1);
                checkPlayerPrefs = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 0);
                if (checkPlayerPrefs == 0)
                {
                    isPersonDouble = false;
                    brawlerDropImageRewared.gameObject.SetActive(true);
                    brawlerDropImageRewared.sprite = allBrawlers[randIndexBrawl].imageBrawler;
                    brawlerNameDropTextRewared.text = allBrawlers[randIndexBrawl].nameBrawler;
                    PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 1);
                }              
                else
                {
                    isPersonDouble = true;
                    brawlerDropImageRewared.gameObject.SetActive(false);
                    brawlerNameDropTextRewared.text = "";
                    screepPerson.SetActive(false);
                    screepAll.SetActive(true);
                }
                break;
            case 1:
                randIndexBrawl = Random.Range(lowIndexDropBox2, highIndexDropBox2);
                checkPlayerPrefs = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 0);
                if (checkPlayerPrefs == 0)
                {
                    isPersonDouble = false;
                    brawlerDropImageRewared.gameObject.SetActive(true);
                    brawlerDropImageRewared.sprite = allBrawlers[randIndexBrawl].imageBrawler;
                    brawlerNameDropTextRewared.text = allBrawlers[randIndexBrawl].nameBrawler;
                    PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 1);
                }
                else
                {
                    isPersonDouble = true;
                    brawlerDropImageRewared.gameObject.SetActive(false);
                    brawlerNameDropTextRewared.text = "";
                    screepPerson.SetActive(false);
                    screepAll.SetActive(true);
                }
                break;
            case 2:
                randIndexBrawl = Random.Range(lowIndexDropBox3, highIndexDropBox3);
                checkPlayerPrefs = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 0);
                if (checkPlayerPrefs == 0)
                {
                    isPersonDouble = false;
                    brawlerDropImageRewared.gameObject.SetActive(true);
                    brawlerDropImageRewared.sprite = allBrawlers[randIndexBrawl].imageBrawler;
                    brawlerNameDropTextRewared.text = allBrawlers[randIndexBrawl].nameBrawler;
                    PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 1);
                }
                else
                {
                    isPersonDouble = true;
                    brawlerDropImageRewared.gameObject.SetActive(false);
                    brawlerNameDropTextRewared.text = "";
                    screepPerson.SetActive(false);
                    screepAll.SetActive(true);
                }
                break;
            case 3:
                randIndexBrawl = Random.Range(lowIndexDropBox4, highIndexDropBox4);
                checkPlayerPrefs = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 0);
                if (checkPlayerPrefs == 0)
                {
                    isPersonDouble = false;
                    brawlerDropImageRewared.gameObject.SetActive(true);
                    brawlerDropImageRewared.sprite = allBrawlers[randIndexBrawl].imageBrawler;
                    brawlerNameDropTextRewared.text = allBrawlers[randIndexBrawl].nameBrawler;
                    PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + randIndexBrawl, 1);
                }
                else
                {
                    isPersonDouble = true;
                    brawlerDropImageRewared.gameObject.SetActive(false);
                    brawlerNameDropTextRewared.text = "";
                    screepPerson.SetActive(false);
                    screepAll.SetActive(true);
                }
                break;
            default:
                break;
        }

        dropScreenAll.personImage.sprite = allBrawlers[randIndexBrawl].imageBrawler;
        dropScreenAll.personNameProfit.text = allBrawlers[randIndexBrawl].nameBrawler;

    }

    public void BoxesAnimationsGo()
    {
        foreach (var item in animatorsBoxes)
        {
            item.SetActive(false);
            item.SetActive(true);
        }
    }

}
