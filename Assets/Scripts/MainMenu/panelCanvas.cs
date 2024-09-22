using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class panelCanvas : Panel
{
    public Button button4x4;
    public Button button6x6;
    public Button button8x8;
    public Button button10x10;
    public Button playButton;
    public Button statPanelButton;
    public Button customPopup;
    public Button exitButton;

    private void Start()
    {
        button4x4.onClick.AddListener(() => GridModeSelect(4, 4));
        button6x6.onClick.AddListener(() => GridModeSelect(6, 6));
        button8x8.onClick.AddListener(() => GridModeSelect(8, 8));
        button10x10.onClick.AddListener(() => GridModeSelect(10, 10));
        playButton.onClick.AddListener(PlayButton);
        statPanelButton.onClick.AddListener(StatPanelButton);
        customPopup.onClick.AddListener(CustomPopupButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    private void GridModeSelect(int columns, int rows)
    {
        GridSetting.Instance.SetGridSize(columns, rows);
    }

    private void PlayButton()
    {
        SceneManager.LoadScene("Gameplay");
        ClientCoordinator.Instance.Clear();
    }
    private void StatPanelButton()
    {
        ClientCoordinator.Instance.OpenOverlay<Popup_Stat>(showOnTop: true).StatPopupSetup();

        // or we can do below way, we save our method in statPanel and then we can call it back.
        //Popup_Stat statPanel = ClientCoordinator.Instance.OpenOverlay<Popup_Stat>(showOnTop: true);
        //statPanel.StatPopupSetup();
    }
    void CustomPopupButton()
    {
        CustomPopup customPopup = ClientCoordinator.Instance.OpenOverlay<CustomPopup>(showOnTop: true);

        Action okAction = () => { SceneManager.LoadScene("Gameplay"); };
        Action closeAction = () => { Debug.Log("Close Button Pressed"); };


        customPopup.CustomSetup("Custom" , "Hello , This is a Custom Popup" , true , "Start" , okAction , closeAction);
    }

    void ExitButton()
    {
        Exit exit = new Exit();
        exit.ExitButtonSetup();
    }


}
