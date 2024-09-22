using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : Popup
{
    public void ExitButtonSetup()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
