using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesConteiner : MonoBehaviour
{

    AudioController audioController;

    [HideInInspector]public int coins;
    public Text[] coinsUi;
    [HideInInspector] public int gems;
    public Text[] gemsUi;
    [HideInInspector] public int tickets;
    public Text[] ticketsUi;



    private void Awake()
    {
        coins = PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_COINS_COUNT, 0);
        foreach (var item in coinsUi)
            item.text = coins.ToString();
        gems = PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_GEMS_COUNT, 0);
        foreach (var item in gemsUi)
            item.text = gems.ToString();
        tickets = PlayerPrefs.GetInt(GameManager.PLAYER_PREFS_KEY_TICKETS_COUNT, 0);
        foreach (var item in ticketsUi)
            item.text = tickets.ToString();

    }


    private void OnEnable()
    {
        
    }



    private void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();
    }


    public void AddCoins(int deltaCoins, WhatIsResourcesGet whatIsResourcesGet, int deltaNewResource)
    {
        int newValue = coins + deltaCoins;
        if (newValue < 0)
        {
            //NeedFix можно сделать Toast как в АС 
            return;
        }

        coins = newValue;
        PlayerPrefs.SetInt(GameManager.PLAYER_PREFS_KEY_COINS_COUNT, coins);
        foreach (var item in coinsUi)
            item.text = coins.ToString();


        switch (whatIsResourcesGet)
        {
            case WhatIsResourcesGet.nothing:
                audioController.PlayGetCoins();
                break;
            case WhatIsResourcesGet.coins:
                
                break;
            case WhatIsResourcesGet.gems:
                AddGems(deltaNewResource, WhatIsResourcesGet.nothing, 0);
                break;
            case WhatIsResourcesGet.tickets:
                AddTickets(deltaNewResource, WhatIsResourcesGet.nothing, 0);
                break;
            default:
                break;
        }


    }


    public void AddGems(int deltaGems, WhatIsResourcesGet whatIsResourcesGet, int deltaNewResource)
    {
        int newValue = gems + deltaGems;
        if (newValue < 0)
        {
            //NeedFix можно сделать Toast как в АС 
            return;
        }

        gems = newValue;
        PlayerPrefs.SetInt(GameManager.PLAYER_PREFS_KEY_GEMS_COUNT, gems);
        foreach (var item in gemsUi)
            item.text = gems.ToString();


        switch (whatIsResourcesGet)
        {
            case WhatIsResourcesGet.nothing:
                audioController.PlayBuyGems();
                break;
            case WhatIsResourcesGet.coins:
                AddCoins(deltaNewResource, WhatIsResourcesGet.nothing, 0);
                break;
            case WhatIsResourcesGet.gems:
                
                break;
            case WhatIsResourcesGet.tickets:
                AddTickets(deltaNewResource, WhatIsResourcesGet.nothing, 0);
                break;
            default:
                break;
        }


    }


    public void AddTickets(int deltaTickets, WhatIsResourcesGet whatIsResourcesGet, int deltaNewResource)
    {
        int newValue = tickets + deltaTickets;
        if (newValue < 0)
        {
            //NeedFix можно сделать Toast как в АС 
            return;
        }

        tickets = newValue;
        PlayerPrefs.SetInt(GameManager.PLAYER_PREFS_KEY_TICKETS_COUNT, tickets);
        foreach (var item in ticketsUi)
            item.text = tickets.ToString();


        switch (whatIsResourcesGet)
        {
            case WhatIsResourcesGet.nothing:
                audioController.PlayGetTickets();
                break;
            case WhatIsResourcesGet.coins:
                AddCoins(deltaNewResource, WhatIsResourcesGet.nothing, 0);
                break;
            case WhatIsResourcesGet.gems:
                AddGems(deltaNewResource, WhatIsResourcesGet.nothing, 0);
                break;
            case WhatIsResourcesGet.tickets:
                
                break;
            default:
                break;
        }


    }








}
