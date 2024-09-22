using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHolder
{
    public static event Action<int> OnScoreUpdate;
    public static void CallOnScoreUpdate(int addedScore) => OnScoreUpdate?.Invoke(addedScore);

}
