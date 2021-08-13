using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropScreenAll : MonoBehaviour
{

    int counterExit;
    int counterExit2;
    UnityAds unityAds;
    public Image resourceImage;
    public Text resourceTextProfit;

    public Image personImage;
    public Text personNameProfit;

    public int valueSkip = 3;

    private void Awake()
    {
        counterExit = 0;
        counterExit2 = 0;
    }

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        unityAds = GameObject.FindObjectOfType<UnityAds>();
    }


    private void OnDisable()
    {
        counterExit++;
        if (counterExit == valueSkip)
        {
            counterExit = 0;
            unityAds.VideoSendOut();
        }
        print("OnDisable DropScreenAll = " + counterExit);


        counterExit2++;
        if (counterExit2 % 10 == 0)
            unityAds.InvokeRateUsAction();




    }




}
