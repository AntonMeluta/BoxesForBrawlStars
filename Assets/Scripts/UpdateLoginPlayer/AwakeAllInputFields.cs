using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AwakeAllInputFields : MonoBehaviour
{
    InputField inputField;
    string awakeStringText;
    public Text textLoginInUi;

    private void Awake()
    {
        inputField = GetComponent<InputField>();        
    }

    private void OnEnable()
    {
        awakeStringText =
                PlayerPrefs.GetString(PlayerAttributes.PLAYER_PREFS_LOGIN_PLAYER, "PLAYER");
        if (awakeStringText != "PLAYER")
            inputField.text = awakeStringText;
    }

    public void SaveUpdateLogin()
    {
        PlayerPrefs.SetString(PlayerAttributes.PLAYER_PREFS_LOGIN_PLAYER, inputField.text);
        textLoginInUi.text = inputField.text;

    }


}
