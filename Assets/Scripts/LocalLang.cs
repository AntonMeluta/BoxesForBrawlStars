using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalLang : MonoBehaviour
{
    SystemLanguage systemLanguage;
    string langStrok = "";
    Text text;

    public string RUS;
    public string ENG;

    //public bool updateLang = false;


    private void Start()
    {
        systemLanguage = Application.systemLanguage;
        text = GetComponent<Text>();

        if (systemLanguage == SystemLanguage.Russian)
            langStrok = RUS;
        else
            langStrok = ENG;

        text.text = langStrok;

    }

   /* private void Update()
    {
        if (updateLang)
        {
            langStrok = RUS;
            text.text = langStrok;
        }
        else
        {
            langStrok = ENG;
            text.text = langStrok;
        }
    }*/





}
