using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridsLoseState : GridsBaseState
{
    public override void EnterState(GridManagerState tileManager)
    {
        Debug.Log("GameOver");
        Time.timeScale = 0.0f;
    }

    public override void UpdateState(GridManagerState tileManager)
    {

    }
}
