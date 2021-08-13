using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour
{
    AudioController audioController;

    public TypeSound typeSound;


    private void Awake()
    {
        audioController = GameObject.FindObjectOfType<AudioController>();


    }

    private void OnEnable()
    {
        switch (typeSound)
        {
            case TypeSound.boxDrop:
                audioController.PlaySafeDrop();
                break;
            case TypeSound.brawlUnlock:
                audioController.PlayBrawlUnlock();
                break;
            case TypeSound._2xGatcha:
                audioController.Play2xGatcha();
                break;
            case TypeSound.selectBrawler:
                audioController.PlaySelectBrawler();
                break;
            default:
                break;
        }
    }


}


public enum TypeSound
{
    boxDrop,
    brawlUnlock,
    _2xGatcha,
    selectBrawler

}
