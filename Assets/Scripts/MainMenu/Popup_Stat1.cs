using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Popup_Stat1 : Popup
{
    public Button CloseButton;
    public Text Content;
    public Text HeaderText;

    public void StatPopup1Setup()
    {
        HeaderText.text = "Popup Panel";
        CloseButton.onClick.AddListener(OnClose);
    }
    void OnClose()
    {
        ClientCoordinator.Instance.CloseOverlay(this);
    }
}
