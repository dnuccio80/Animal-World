using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Callback : MonoBehaviour
{

    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Load.LoadScene();
        }
    }




}
