using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    AudioSource audioSource;

    public AudioClip _2xGatcha;
    public AudioClip brawlUnlock;
    public AudioClip gemsGatcha;
    public AudioClip getCoins;
    public AudioClip getTickets;
    public AudioClip menuClick;
    public AudioClip menGoBack;
    public AudioClip safeDrop;
    public AudioClip selectBrawler;
    public AudioClip buyGems;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }



    public void Play2xGatcha()
    {
        audioSource.clip = _2xGatcha;
        audioSource.Play();
    }

    public void PlayBrawlUnlock()
    {
        audioSource.clip = brawlUnlock;
        audioSource.Play();
    }

    public void PlayGemsGatcha()
    {
        audioSource.clip = gemsGatcha;
        audioSource.Play();
    }

    public void PlayGetCoins()
    {
        audioSource.clip = getCoins;
        audioSource.Play();
    }

    public void PlayGetTickets()
    {
        audioSource.clip = getTickets;
        audioSource.Play();
    }

    public void PlayMenuClick()
    {
        audioSource.clip = menuClick;
        audioSource.Play();
    }

    public void PlayMenGoBack()
    {
        audioSource.clip = menGoBack;
        audioSource.Play();
    }

    public void PlaySafeDrop()
    {
        audioSource.clip = safeDrop;
        audioSource.Play();
    }

    public void PlaySelectBrawler()
    {
        audioSource.clip = selectBrawler;
        audioSource.Play();
    }

    public void PlayBuyGems()
    {
        audioSource.clip = buyGems;
        audioSource.Play();
    }



}
