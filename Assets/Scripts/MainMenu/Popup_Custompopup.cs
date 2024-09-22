using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPopup : Popup
{
    public Text HeaderText;
    public Text ContentText;
    public Text okText;
    public Button closeButton;
    public Button okButton;
    public void CustomSetup(string headerText, string contentText, bool okbutton, string oktext, Action onOkPressed = null, Action onClosed = null)
    {
        HeaderText.text = headerText;
        ContentText.text = contentText;
        okText.text = oktext;   
        okButton.gameObject.SetActive(okbutton);

        closeButton.onClick.AddListener(() =>
        {

            onClosed?.Invoke();

            ClientCoordinator.Instance.CloseOverlay(this);
        });

        okButton.onClick.AddListener(() =>
        {
            onOkPressed?.Invoke();

            ClientCoordinator.Instance.CloseOverlay(this);
        });
    }
}
