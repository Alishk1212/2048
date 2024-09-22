using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class GridManagerState : MonoBehaviour
{
    [SerializeField]
    public TileScript tilePrefab;

    [SerializeField]
    public NumeberScript playerTilePrefab;

    public Transform PrefabsInstantiatePlace;

    public int columns;
    public int rows;

    public bool canMerge = true;
    public bool canUndo = false;

    public GridData[,] gridData;

    public GridsBaseState currentState;

    public GridsCreatorState creatorState;
    public GridsSpawnState spawnState;
    public GridsDetectEmptyGridsState detectEmptyGridsState;
    public GridsMovementState movementState;
    public GridsMovementCheckState gridsMovementCheckState;
    public GridsWinLoseState winLoseState;
    public GridsLoseState loseState;
    public SaveState saveState;

    public DirectionMove direction;


    void Start()
    {
        columns = GridSetting.Instance.GridColumns;
        rows = GridSetting.Instance.GridRows;

        creatorState = new GridsCreatorState();
        spawnState = new GridsSpawnState();
        detectEmptyGridsState = new GridsDetectEmptyGridsState();
        movementState = new GridsMovementState();
        gridsMovementCheckState = new GridsMovementCheckState();
        winLoseState = new GridsWinLoseState();
        loseState = new GridsLoseState();
        saveState = new SaveState();
        currentState = creatorState;
        currentState.EnterState(this);

    }


    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GridsBaseState newState)
    {
        currentState = newState;
        newState.EnterState(this);
    }

    public enum DirectionMove
    {
        RightMove,
        LeftMove,
        UpMove,
        DownMove
    }

}

