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
        coins = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_COINS_COUNT, 0);
        foreach (var item in coinsUi)
            item.text = coins.ToString();
        gems = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_GEMS_COUNT, 0);
        foreach (var item in gemsUi)
            item.text = gems.ToString();
        tickets = PlayerPrefs.GetInt(PlayerAttributes.PLAYER_PREFS_KEY_TICKETS_COUNT, 0);
        foreach (var item in ticketsUi)
            item.text = tickets.ToString();

    }
    
    private void Start()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();
    }


    public void AddCoins(int deltaCoins)
    {
        int newValue = coins + deltaCoins;
        coins = newValue;
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_COINS_COUNT, coins);
        foreach (var item in coinsUi)
            item.text = coins.ToString();
        audioController.PlayGetCoins();
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
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_COINS_COUNT, coins);
        foreach (var item in coinsUi)
            item.text = coins.ToString();
        audioController.PlayGetCoins();

        switch (whatIsResourcesGet)
        {      
            case WhatIsResourcesGet.coins:                
                break;
            case WhatIsResourcesGet.gems:
                AddGems(deltaNewResource);
                break;
            case WhatIsResourcesGet.tickets:
                AddTickets(deltaNewResource);
                break;
            default:
                break;
        }
    }


    public void AddGems(int deltaGems)
    {
        int newValue = gems + deltaGems;
        gems = newValue;
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_GEMS_COUNT, gems);
        foreach (var item in gemsUi)
            item.text = gems.ToString();
        audioController.PlayBuyGems();
    }

    public void AddGems(int deltaGems, WhatIsResourcesGet whatIsResourcesGet, int deltaNewResource)
    {
        int newValue = gems + deltaGems;
        if (newValue < 0)
        {
            //NeedFix можно сделать Toast как в АС, интерфейсы
            return;
        }

        gems = newValue;
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_GEMS_COUNT, gems);
        foreach (var item in gemsUi)
            item.text = gems.ToString();
        audioController.PlayBuyGems();

        switch (whatIsResourcesGet)
        {            
            case WhatIsResourcesGet.coins:
                AddCoins(deltaNewResource);
                break;
            case WhatIsResourcesGet.gems:                
                break;
            case WhatIsResourcesGet.tickets:
                AddTickets(deltaNewResource);
                break;
            default:
                break;
        }
    }


    public void AddTickets(int deltaTickets)
    {
        int newValue = tickets + deltaTickets;
        tickets = newValue;
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_TICKETS_COUNT, tickets);
        foreach (var item in ticketsUi)
            item.text = tickets.ToString();
        audioController.PlayGetTickets();
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
        PlayerPrefs.SetInt(PlayerAttributes.PLAYER_PREFS_KEY_TICKETS_COUNT, tickets);
        foreach (var item in ticketsUi)
            item.text = tickets.ToString();
        audioController.PlayGetTickets();

        switch (whatIsResourcesGet)
        {            
            case WhatIsResourcesGet.coins:
                AddCoins(deltaNewResource);
                break;
            case WhatIsResourcesGet.gems:
                AddGems(deltaNewResource);
                break;
            case WhatIsResourcesGet.tickets:                
                break;
            default:
                break;
        }
    }
    
}
