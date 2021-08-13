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
    
}
