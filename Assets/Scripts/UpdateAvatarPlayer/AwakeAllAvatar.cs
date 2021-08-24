using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeAllAvatar : MonoBehaviour
{
    public GameObject parentObject;
    public GameObject lockImage;

    Button button;
    public StorageFighters storageFighters;

    public int indexBrawlerAvatar;
    string getName;

    public Image imageIconAvatarMajorScreen;

    public bool isPlayerAvatar = false;
    public Sprite playerDefaultAvatar;

    private void Awake()
    {
        button = GetComponent<Button>();
        getName = storageFighters.collectionBrawlers[indexBrawlerAvatar].nameBrawler;
        button.onClick.AddListener(MethodAvatarPress);
    }

    private void OnEnable()
    {
        int permissionINdex = 
            PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_NAME_BRAWLER + indexBrawlerAvatar, 0);
        if (isPlayerAvatar || permissionINdex == 1)
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
        Sprite spriteAvatar;

        if (isPlayerAvatar)
            spriteAvatar = playerDefaultAvatar;
        else
            spriteAvatar = storageFighters.collectionBrawlers[indexBrawlerAvatar].avatarBrawler;

        imageIconAvatarMajorScreen.sprite = spriteAvatar;
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_INDEX_AVATAR, indexBrawlerAvatar);
        parentObject.SetActive(false);
    }

}
