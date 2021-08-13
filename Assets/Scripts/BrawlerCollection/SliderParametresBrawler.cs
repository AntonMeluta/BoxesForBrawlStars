using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderParametresBrawler : MonoBehaviour
{

    Slider[] allSliders;
    string nameCurrentBrawlerAtScreen;

    [HideInInspector]public int getAttackValue = 0;
    [HideInInspector] public int getHealthValue = 0;
    [HideInInspector] public int getSuperValue = 0;

    private void Awake()
    {
        allSliders = GetComponentsInChildren<Slider>();
    }


    public void GetValues(int attack, int health, int super)
    {
        getAttackValue = attack;
        getHealthValue = health;
        getSuperValue = super;
        for (int i = 0; i < allSliders.Length; i++)
        {
            if (i == 0)
            {
                allSliders[0].value = getAttackValue;
            }

            if (i == 1)
            {
                allSliders[1].value = getHealthValue;
            }

            if (i == 2)
            {
                allSliders[2].value = getSuperValue;
            }
        }
    }



}
