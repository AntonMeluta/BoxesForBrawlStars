using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrawlerInfo : MonoBehaviour
{    
    public Text nameHeaderBrawlerText;
    public Text infoBrawlerFieldText;
    public Image imageBrawlerFull;

    public Slider sliderAttackValue;
    public Slider sliderHealthValue;
    public Slider sliderSuperValue;

    
    public void GetInfoAboutNeedBrawler(string name, string brawlerInfo, Sprite spriteBrawler,
        int attackValue, int healthValue, int superValue)
    {
        nameHeaderBrawlerText.text = name;
        infoBrawlerFieldText.text = brawlerInfo;
        imageBrawlerFull.sprite = spriteBrawler;

        sliderAttackValue.value = attackValue;
        sliderHealthValue.value = healthValue;
        sliderSuperValue.value = superValue;
    }

}
