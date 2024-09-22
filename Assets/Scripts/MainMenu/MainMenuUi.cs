using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{

    void Start()
    {
        ClientCoordinator.Instance.OpenOverlay<panelCanvas>();

        DateTime targetTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 20, 5, 0);

        StartCoroutine(CountdownToTargetTime(targetTime));

    }

    private void Update()
    {

    }

    IEnumerator customTimer(float maxTimer)
    {

        DateTime dateTime = DateTime.MinValue;

        float duration = 0;

        while (duration < maxTimer)
        {
            yield return new WaitForSeconds(1);

            maxTimer--;

            DateTime timerCounter = dateTime.AddSeconds(maxTimer);
            Debug.Log(timerCounter);
        }
        Debug.Log("Fineshed");
    }


    private IEnumerator CountdownToTargetTime(DateTime targetTime)
    {
        DateTime currentTime = DateTime.Now;

        while (currentTime < targetTime)
        {
            yield return new WaitForSeconds(1f); 


            currentTime = DateTime.Now;


            TimeSpan timeRemaining = targetTime - currentTime;


            if (timeRemaining.TotalSeconds < 0)
                timeRemaining = TimeSpan.Zero;


            Debug.Log($"Time Remaining until offset: {timeRemaining.Hours:D2}:{timeRemaining.Minutes:D2}:{timeRemaining.Seconds:D2}");
        }

        Debug.Log($"Offset Time Reached = {targetTime.ToString()}");
    }
}
