using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Добавить поздравления при выполнении ачивок
public class PlayerAttributes : MonoBehaviour
{
    public static string PLAYER_PREFS_INDEX_AVATAR = "INDEX_AVATAR";
    public static string PLAYER_PREFS_KEY_NAME_BRAWLER = "NAME_BRAWLER";
    public static string PLAYER_PREFS_LOGIN_PLAYER = "LOGIN_PLAYER";
    public static string PLAYER_PREFS_FIRST_START = "FIRST_START";
    public static string PLAYER_PREFS_KEY_COINS_COUNT = "countCoins";
    public static string PLAYER_PREFS_KEY_GEMS_COUNT = "countGems";
    public static string PLAYER_PREFS_KEY_TICKETS_COUNT = "countTickets";
    public static string PLAYER_PREFS_KEY_CHEST_TYPE = "chestType";
    public static string PLAYER_PREFS_KEY_CHEST_HOWMUCHOPENING = "chestHowMuch";

    public Image avatarUiIcon;
    public string[] containerNamesBrawlersInString;
    public Sprite[] conteinerSpritesBrawlersAll;
    public Sprite[] conteinerSpritesAvatarsBrawlersAll;

    public GameObject firstInputFieldSection;
    public Text textNamePlayerMainScreen;


    private void Awake()
    {
        int firstStart = PlayerPrefs.GetInt(PLAYER_PREFS_FIRST_START, 0);
        if (firstStart == 0)
        {
            firstInputFieldSection.SetActive(true);
            firstStart = 1;
            PlayerPrefs.SetInt(PLAYER_PREFS_FIRST_START, firstStart);
            GameManager.instance.TransitionToLoginState();
        }

        SetNameInputField();
        SetAvatar();
    }

    void SetNameInputField()
    {
        string getNamePlayer = PlayerPrefs.GetString(PLAYER_PREFS_LOGIN_PLAYER, "PLAYER");
        textNamePlayerMainScreen.text = getNamePlayer;
    }

    void SetAvatar()
    {
        int indexAvatarCurrent = PlayerPrefs.GetInt(PLAYER_PREFS_INDEX_AVATAR, 0);
        avatarUiIcon.sprite = conteinerSpritesAvatarsBrawlersAll[indexAvatarCurrent];
    }        
}




