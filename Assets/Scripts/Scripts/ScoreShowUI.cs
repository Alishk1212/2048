using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreShowUI : Popup
{
    public Text scoreText;
    GridsMovementState gridsMovementState;

    private void OnEnable()
    {
        EventHolder.OnScoreUpdate += UpdateScoreValue;
    }
    private void OnDisable()
    {
        EventHolder.OnScoreUpdate -= UpdateScoreValue;
    }

    private void UpdateScoreValue(int score)
    {
        scoreText.text = score.ToString("000");
    }
}
