using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //rateUs
    int isRateUS;
    public GameObject rateUsObj;
    public string rateUsRef;

    [SerializeField]GameState currentState;
    public GameState CurrentState
    {
        get
        {
            return currentState;
        }
        private set{ }
    }

    private void Awake()
    {
        UpdateGameState(GameState.HomeScreen);
    }

    
    void UpdateGameState(GameState state)
    {
        GameState prevGameState = currentState;
        currentState = state;

        switch (state)
        {
            case GameState.HomeScreen:
                break;
            case GameState.AvatarUpdateScreen:
                break;
            case GameState.LoginUpdateScreen:
                break;
            case GameState.BrawlerCollectionScreen:
                break;
            case GameState.ShopScreen:
                break;
            case GameState.AchievementsScreen:
                break;
            default:
                break;
        }

    }

    public void InvokeRateUsAction()
    {        
        /*isRateUS = PlayerPrefs.GetInt("isRateUS", 0);
        if (isRateUS == 0)
            rateUsObj.SetActive(true);*/
    }

    public void RateUsHere()
    {
        isRateUS = 1;
        PlayerPrefs.SetInt("isRateUS", isRateUS);
        rateUsObj.SetActive(false);
        Application.OpenURL(rateUsRef);
    }


    public void TransitionToAvatarState()
    {
        UpdateGameState(GameState.AvatarUpdateScreen);
    }

    public void TransitionToHomeScreenState()
    {
        UpdateGameState(GameState.HomeScreen);
    }

    public void TransitionToLoginState()
    {
        UpdateGameState(GameState.LoginUpdateScreen);
    }

    public void TransitionToBrawlCollectionState()
    {
        UpdateGameState(GameState.BrawlerCollectionScreen);
    }

    public void TransitionToShopState()
    {
        UpdateGameState(GameState.ShopScreen);
    }

    public void TransitionToAchievementState()
    {
        UpdateGameState(GameState.AchievementsScreen);
    }

    public void TransitionToHuntBoxesState()
    {
        UpdateGameState(GameState.HuntingForBoxes);
    }
}

public enum GameState
{
    HomeScreen,
    AvatarUpdateScreen,
    LoginUpdateScreen,
    BrawlerCollectionScreen,
    ShopScreen,
    AchievementsScreen,
    HuntingForBoxes
}

public enum Brawlers
{
    daefaultName0,
    Shelly,
    _8_bit,
    Emz,
    Colt,
    Nita,
    Bo,
    Dynomike,
    Jessie,
}
public enum WhatIsResourcesGet
{
    coins,
    gems,
    tickets
}
public enum ResourcesButton
{
    coin,
    gem,
    ticket
}
public enum TargetPickupedResourcesEnum
{
    toPickupGem,
    toPickupCoin,
    toPickupTicket
}
public enum TypeBrawler
{
    allBrawler,
    standart,
    rare,
    ultrarare,
    epic,
    mythical,
    legend
}
