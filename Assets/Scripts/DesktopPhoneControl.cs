using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopPhoneControl : MonoBehaviour
{
    public Sprite[] allSpritesPhones;
    int indexCurent = 0;
    Image image;


    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        indexCurent = PlayerPrefs.GetInt("phoneBack", 0);
        image.sprite = allSpritesPhones[indexCurent];
    }

    public void UpdateCurrentIndex(int getIndex)
    {
        indexCurent = getIndex;
        PlayerPrefs.SetInt("phoneBack", indexCurent);
        image.sprite = allSpritesPhones[indexCurent];
    }



}
