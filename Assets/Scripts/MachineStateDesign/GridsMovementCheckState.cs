using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static GridManagerState;

public class GridsMovementCheckState : GridsBaseState
{
    int emptyPos;
    int move;
    int lastNumber;

    public override void EnterState(GridManagerState tileManager)
    {
        switch (tileManager.direction)
        {
            case DirectionMove.RightMove:

                for (int y = 0; y < tileManager.rows; y++)
                {
                    emptyPos = 0;
                    move = 0;
                    lastNumber = 0;
                    bool mergedTile = false;

                    for (int x = tileManager.columns - 1; x >= 0; x--)
                    {
                        NumeberScript tile = tileManager.gridData[x, y].tileNumber;

                        if (tile == null)
                        {
                            emptyPos++;
                        }
                        else
                        {
                            if (tile.getValue() == lastNumber && !mergedTile)
                            {
                                emptyPos++;
                                move = emptyPos;
                                tile.setMove(move);
                                mergedTile = true;
                            }
                            else
                            {
                                move = emptyPos;
                                lastNumber = tile.getValue();
                                tile.setMove(move);
                                mergedTile = false;
                            }
                        }
                    }
                }
                break;


            case DirectionMove.LeftMove:
                for (int y = 0; y < tileManager.rows; y++)
                {
                    emptyPos = 0;
                    move = 0;
                    lastNumber = 0;
                    bool mergedTile = false;

                    for (int x = 0; x < tileManager.columns; x++)
                    {
                        NumeberScript tile = tileManager.gridData[x, y].tileNumber;

                        if (tile == null)
                        {
                            emptyPos++;
                        }
                        else
                        {
                            if (tile.getValue() == lastNumber && !mergedTile)
                            {
                                emptyPos++;
                                move = emptyPos;
                                tile.setMove(move);

                                mergedTile = true;
                            }
                            else
                            {
                                move = emptyPos;
                                lastNumber = tile.getValue();
                                tile.setMove(move);

                                mergedTile = false;
                            }
                        }
                    }
                }
                break;


            case DirectionMove.UpMove:

                for (int x = 0; x < tileManager.columns; x++)
                {
                    emptyPos = 0;
                    move = 0;
                    lastNumber = 0;
                    bool mergedTile = false;

                    for (int y = tileManager.rows - 1; y >= 0; y--)
                    {
                        NumeberScript tile = tileManager.gridData[x, y].tileNumber;

                        if (tile == null)
                        {
                            emptyPos++;
                        }
                        else
                        {
                            if (tile.getValue() == lastNumber && !mergedTile)
                            {
                                emptyPos++;
                                move = emptyPos;
                                tile.setMove(move);
                                mergedTile = true;
                            }
                            else
                            {
                                move = emptyPos;
                                lastNumber = tile.getValue();
                                tile.setMove(move);
                                mergedTile = false;
                            }
                        }
                    }
                }
                break;

            case DirectionMove.DownMove:

                for (int x = 0; x < tileManager.columns; x++)
                {
                    emptyPos = 0;
                    move = 0;
                    lastNumber = 0;
                    bool mergedTile = false;

                    for (int y = 0; y < tileManager.rows; y++)
                    {
                        NumeberScript tile = tileManager.gridData[x, y].tileNumber;

                        if (tile == null)
                        {
                            emptyPos++;
                        }
                        else
                        {
                            if (tile.getValue() == lastNumber && !mergedTile)
                            {
                                emptyPos++;
                                move = emptyPos;
                                tile.setMove(move);
                                mergedTile = true;
                            }
                            else
                            {
                                move = emptyPos;
                                lastNumber = tile.getValue();
                                tile.setMove(move);
                                mergedTile = false;

                            }
                        }
                    }
                }
                break;
        }
        tileManager.SwitchState(tileManager.movementState);
    }

    public override void UpdateState(GridManagerState tileManager)
    {

    }
}
