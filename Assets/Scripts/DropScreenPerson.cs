using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScreenPerson : MonoBehaviour
{

    public BoxesContainer boxesContainer;
    public GameObject nextScreen;


    private void OnEnable()
    {
        if (boxesContainer.IsPersonDouble)
        {
            nextScreen.SetActive(true);
            gameObject.SetActive(false);
        }
    
    }


}
