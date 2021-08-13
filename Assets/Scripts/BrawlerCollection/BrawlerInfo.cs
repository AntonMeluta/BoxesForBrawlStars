using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrawlerInfo : MonoBehaviour
{
    
    public Text nameHeaderBrawlerText;
    public Text infoBrawlerFieldText;
    public Image imageBrawlerFull;

    



    private void Awake()
    {
        

        

        
    }

    private void Start()
    {
        
    }


    public void GetInfoAboutNeedBrawler(string nameBrawler, string aboutBrawlerInfo, Sprite spriteBrawlerFull)
    {
        nameHeaderBrawlerText.text = nameBrawler;
        infoBrawlerFieldText.text = aboutBrawlerInfo;
        imageBrawlerFull.sprite = spriteBrawlerFull;
    }





}
