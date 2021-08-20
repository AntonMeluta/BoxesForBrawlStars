using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsGetControl : MonoBehaviour
{
    List<string> arrayCongratulationLines = new List<string>();
    string curentLine;

    public Text textGreetingUI;
    public AudioController audioController;

    public void AddLine(string newLine)
    {        
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            curentLine = newLine;
            textGreetingUI.text = newLine;
            audioController.PlayBrawlUnlock();                     
        }

        arrayCongratulationLines.Add(newLine);
    }

    public void SkipWindowCongratulations()
    {
        arrayCongratulationLines.Remove(curentLine);

        if (arrayCongratulationLines.Count > 0)
        {
            curentLine = arrayCongratulationLines[arrayCongratulationLines.Count - 1];
            textGreetingUI.text = curentLine;
            audioController.PlayBrawlUnlock();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }


}
