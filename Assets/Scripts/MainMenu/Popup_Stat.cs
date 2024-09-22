using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup_Stat : Popup
{
    public Button CloseButton;
    public Button PopupButton;
    public Text Content;
    public Text HeaderText;

    public void StatPopupSetup()
    {
        HeaderText.text = "Stat Panel";
        CloseButton.onClick.AddListener(OnClose);
        PopupButton.onClick.AddListener(OnShowPopupMainMenu);
    }

    //public override void Close()
    //{
    //    base.Close();
    //}

    private void OnShowPopupMainMenu()
    {
        ClientCoordinator.Instance.OpenOverlay<Popup_Stat1>(showOnTop: true).StatPopup1Setup();
        ClientCoordinator.Instance.LoseFocus(this);
    }
    void OnClose()
    {
        ClientCoordinator.Instance.CloseOverlay(this);
    }

}
