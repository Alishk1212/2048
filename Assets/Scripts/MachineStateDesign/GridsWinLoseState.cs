using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using static GridManagerState;

public class GridsWinLoseState : GridsBaseState
{
    public override void EnterState(GridManagerState tileManager)
    {
        int lastNumber;
        int lastNumber1;
        bool lefttDirection = false;
        bool uptDirection = false;
        bool canMove = false;

        List<Vector2Int> emptyPositions = new List<Vector2Int>();

        for (int x = 0; x < tileManager.columns; x++)
        {
            for (int y = 0; y < tileManager.rows; y++)
            {
                if (tileManager.gridData[x, y].tileBase != null && tileManager.gridData[x, y].tileNumber == null)
                {
                    emptyPositions.Add(new Vector2Int(x, y));
                }
            }
        }

        if (emptyPositions.Count == 0)
        {
            Debug.Log($"emptyPositions = {emptyPositions.Count}");

            for (int y = 0; y < tileManager.rows; y++)
            {
                lastNumber = 0;
                lastNumber1 = 0;

                for (int x = tileManager.columns - 1; x > 0; x--)
                {
                    NumeberScript playerTile = tileManager.gridData[x, y].tileNumber;
                    NumeberScript playerTile1 = tileManager.gridData[x - 1, y].tileNumber;

                    lastNumber = playerTile.getValue();
                    lastNumber1 = playerTile1.getValue();

                    if (lastNumber == lastNumber1)
                    {
                        lefttDirection = true;
                        canMove = true;
                    }
                }
            }
            for (int x = tileManager.columns - 1; x >= 0; x--)
            {
                lastNumber = 0;
                lastNumber1 = 0;

                for (int y = 0; y < tileManager.rows - 1; y++)
                {
                    NumeberScript playerTile = tileManager.gridData[x, y].tileNumber;
                    NumeberScript playerTile1 = tileManager.gridData[x, y + 1].tileNumber;

                    lastNumber = playerTile.getValue();
                    lastNumber1 = playerTile1.getValue();

                    if (lastNumber == lastNumber1)
                    {
                        lefttDirection = true;
                        canMove = true;
                    }
                }
            }
            if (canMove)
            {
                tileManager.SwitchState(tileManager.movementState);
            }
            if (!lefttDirection && !uptDirection)
            {
                tileManager.SwitchState(tileManager.loseState);
            }
        }



        tileManager.SwitchState(tileManager.movementState);











        //    bool rightDirection = false;
        //    bool leftDirection = false;
        //    bool upDirection = false;
        //    bool downDirection = false;
        //    bool canMove = false;

        //    for (int y = 0; y < tileManager.rows; y++)
        //    {
        //        for (int x = 0; x < tileManager.columns; x++)
        //        {
        //            if (tileManager.gridData[x, y].tileNumber != null)
        //            {
        //                NumeberScript playerTile = tileManager.gridData[x, y].tileNumber;

        //                tileManager.direction = DirectionMove.RightMove;
        //                tileManager.SwitchState(tileManager.gridsMovementCheckState);
        //                if (playerTile.getMove() > 0)
        //                {
        //                    rightDirection = true;
        //                    canMove = true;
        //                }

        //                tileManager.direction = DirectionMove.LeftMove;
        //                tileManager.SwitchState(tileManager.gridsMovementCheckState);
        //                if (playerTile.getMove() > 0)
        //                {
        //                    leftDirection = true;
        //                    canMove = true;
        //                }

        //                tileManager.direction = DirectionMove.UpMove;
        //                tileManager.SwitchState(tileManager.gridsMovementCheckState);
        //                if (playerTile.getMove() > 0)
        //                {
        //                    upDirection = true;
        //                    canMove = true;
        //                }

        //                tileManager.direction = DirectionMove.DownMove;
        //                tileManager.SwitchState(tileManager.gridsMovementCheckState);
        //                if (playerTile.getMove() > 0)
        //                {
        //                    downDirection = true;
        //                    canMove = true;
        //                }

        //                if (canMove)
        //                {
        //                    tileManager.SwitchState(tileManager.movementState);
        //                    return;
        //                }
        //            }
        //        }
        //    }


        //    if (!rightDirection && !leftDirection && !upDirection && !downDirection)
        //    {
        //        tileManager.SwitchState(tileManager.loseState);
        //    }
    }


    public override void UpdateState(GridManagerState tileManager)
    {

    }
}


