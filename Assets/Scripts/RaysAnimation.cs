using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaysAnimation : MonoBehaviour
{

    public float speedRotate = 10;

    private void Update()
    {
        transform.Rotate(0, 0, speedRotate);
    }




}
