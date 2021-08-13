using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeAllAvatar : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject lockImage;

    Button button;
    public GameManager gameManager;

    public int indexBrawlerAvatar;
    string getName;

    public Image imageIconAvatarMajorScreen;
    

    private void Awake()
    {
        button = GetComponent<Button>();
        getName = gameManager.containerNamesBrawlersInString[indexBrawlerAvatar];
        button.onClick.AddListener(MethodAvatarPress);


    }


    private void OnEnable()
    {
        int permissionINdex = 
            PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_NAME_BRAWLER + indexBrawlerAvatar, 0);
        if (indexBrawlerAvatar == 0 || permissionINdex == 1)
        {
            button.interactable = true;
            lockImage.SetActive(false);
        }           
        else 
        {
            button.interactable = false;
            lockImage.SetActive(true);
        }
            

    }


    
    void MethodAvatarPress()
    {
        imageIconAvatarMajorScreen.sprite = gameManager.conteinerSpritesAvatarsBrawlersAll[indexBrawlerAvatar];
        PlayerPrefs.SetInt(GameManager.PLAYER_PREFS_INDEX_AVATAR, indexBrawlerAvatar);
        parentObject.SetActive(false);
    }


}
