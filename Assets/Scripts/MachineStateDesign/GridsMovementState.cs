using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using static GridManagerState;


public class GridsMovementState : GridsBaseState
{
    int scorePoint;
    //public Action<int> OnScoreChanged;
    public override void EnterState(GridManagerState tileManager)
    {


    }

    public override void UpdateState(GridManagerState tileManager)
    {

        bool moveHappened = false;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            tileManager.canUndo = true;
            tileManager.SwitchState(tileManager.saveState);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tileManager.SwitchState(tileManager.saveState);

            tileManager.direction = DirectionMove.RightMove;

            tileManager.SwitchState(tileManager.gridsMovementCheckState);


            for (int y = 0; y < tileManager.rows; y++)
            {
                for (int x = tileManager.columns - 1; x >= 0; x--)
                {
                    NumeberScript playerTilex = tileManager.gridData[x, y].tileNumber;

                    if (playerTilex != null)
                    {
                        int move = playerTilex.getMove();

                        if (move > 0)
                        {
                            int finalMove = x + move;

                            TileScript newTile = tileManager.gridData[finalMove, y].tileBase;

                            NumeberScript targetTile = tileManager.gridData[finalMove, y].tileNumber;

                            if (targetTile != null && targetTile.getValue() == playerTilex.getValue())
                            {
                                tileManager.gridData[x, y].tileNumber = null;

                                LeanTween.move(playerTilex.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                {
                                    int mergedValue = targetTile.getValue() * 2;
                                    targetTile.setValue(mergedValue);
                                    targetTile.UpdateValue();

                                    //tileManager.score += mergedValue;
                                    //tileManager.UpdateScoreValue();

                                    scorePoint += mergedValue;
                                    EventHolder.CallOnScoreUpdate(scorePoint);

                                    //OnScoreChanged?.Invoke(scorePoint);


                                    targetTile.UpdateTileColor();

                                    MonoBehaviour.Destroy(playerTilex.gameObject);

                                    LeanTween.scale(targetTile.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f).setEaseInCubic().setOnComplete(() =>
                                    {
                                        LeanTween.scale(targetTile.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
                                    });

                                });


                                tileManager.gridData[finalMove, y].tileNumber = targetTile;

                                moveHappened = true;

                            }
                            else
                            {
                                tileManager.gridData[x, y].tileNumber = null;

                                LeanTween.move(playerTilex.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                {
                                    playerTilex.transform.position = newTile.transform.position;
                                    playerTilex.transform.parent = newTile.transform;
                                    playerTilex.SetGridPlayerPosition(finalMove, y);
                                });

                                tileManager.gridData[finalMove, y].tileNumber = playerTilex;
                                moveHappened = true;

                            }
                        }
                    }
                }
            }
        }


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tileManager.SwitchState(tileManager.saveState);
            tileManager.direction = DirectionMove.LeftMove;
            tileManager.SwitchState(tileManager.gridsMovementCheckState);

            for (int y = 0; y < tileManager.rows; y++)
            {
                for (int x = 0; x < tileManager.columns; x++)
                {
                    NumeberScript playerTilex = tileManager.gridData[x, y].tileNumber;

                    if (playerTilex != null)
                    {
                        int move = playerTilex.getMove();

                        if (move > 0)
                        {
                            int finalMove = x - move;

                            if (finalMove >= 0)
                            {
                                NumeberScript targetTile = tileManager.gridData[finalMove, y].tileNumber;
                                TileScript newTile = tileManager.gridData[finalMove, y].tileBase;
                                if (targetTile != null && targetTile.getValue() == playerTilex.getValue())
                                {
                                    tileManager.gridData[x, y].tileNumber = null;

                                    LeanTween.move(playerTilex.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                    {
                                        int mergedValue = targetTile.getValue() * 2;
                                        targetTile.setValue(mergedValue);
                                        targetTile.UpdateValue();

                                        //tileManager.score += mergedValue;
                                        //tileManager.UpdateScoreValue();

                                        scorePoint += mergedValue;
                                        //OnScoreChanged?.Invoke(scorePoint);
                                        EventHolder.CallOnScoreUpdate(scorePoint);


                                        targetTile.UpdateTileColor();

                                        MonoBehaviour.Destroy(playerTilex.gameObject);

                                        LeanTween.scale(targetTile.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f).setOnComplete(() =>
                                        {
                                            LeanTween.scale(targetTile.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
                                        });
                                    });


                                    tileManager.gridData[finalMove, y].tileNumber = targetTile;
                                    moveHappened = true;


                                }
                                else
                                {
                                    tileManager.gridData[x, y].tileNumber = null;

                                    LeanTween.move(playerTilex.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                    {
                                        playerTilex.transform.position = newTile.transform.position;
                                        playerTilex.transform.parent = newTile.transform;
                                        playerTilex.SetGridPlayerPosition(finalMove, y);

                                    });

                                    tileManager.gridData[finalMove, y].tileNumber = playerTilex;
                                    moveHappened = true;
                                }


                            }

                        }
                    }
                }
            }

        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tileManager.SwitchState(tileManager.saveState);
            tileManager.direction = DirectionMove.UpMove;
            tileManager.SwitchState(tileManager.gridsMovementCheckState);

            for (int x = 0; x < tileManager.columns; x++)
            {
                for (int y = tileManager.rows - 1; y >= 0; y--)
                {
                    NumeberScript playerTiley = tileManager.gridData[x, y].tileNumber;

                    if (playerTiley != null)
                    {
                        int move = playerTiley.getMove();

                        if (move > 0)
                        {
                            int finalMove = y + move;
                            NumeberScript targetTile = tileManager.gridData[x, finalMove].tileNumber;
                            TileScript newTile = tileManager.gridData[x, finalMove].tileBase;

                            if (targetTile != null && targetTile.getValue() == playerTiley.getValue())
                            {
                                tileManager.gridData[x, y].tileNumber = null;

                                LeanTween.move(playerTiley.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                {
                                    int mergedValue = targetTile.getValue() * 2;
                                    targetTile.setValue(mergedValue);
                                    targetTile.UpdateValue();

                                    //tileManager.score += mergedValue;
                                    //tileManager.UpdateScoreValue();

                                    scorePoint += mergedValue;
                                    EventHolder.CallOnScoreUpdate(scorePoint);

                                    //OnScoreChanged?.Invoke(scorePoint);

                                    targetTile.UpdateTileColor();

                                    MonoBehaviour.Destroy(playerTiley.gameObject);

                                    LeanTween.scale(targetTile.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f).setOnComplete(() =>
                                    {
                                        LeanTween.scale(targetTile.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
                                    });
                                });


                                tileManager.gridData[x, finalMove].tileNumber = targetTile;
                                moveHappened = true;

                            }
                            else
                            {
                                tileManager.gridData[x, y].tileNumber = null;

                                LeanTween.move(playerTiley.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                {
                                    playerTiley.transform.position = newTile.transform.position;
                                    playerTiley.transform.parent = newTile.transform;
                                    playerTiley.SetGridPlayerPosition(x, finalMove);
                                });

                                tileManager.gridData[x, finalMove].tileNumber = playerTiley;
                                moveHappened = true;
                            }

                        }
                    }
                }
            }

        }


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tileManager.SwitchState(tileManager.saveState);
            tileManager.direction = DirectionMove.DownMove;
            tileManager.SwitchState(tileManager.gridsMovementCheckState);

            for (int x = 0; x < tileManager.columns; x++)
            {
                for (int y = 0; y < tileManager.rows; y++)
                {
                    NumeberScript playerTiley = tileManager.gridData[x, y].tileNumber;

                    if (playerTiley != null)
                    {
                        int move = playerTiley.getMove();

                        if (move > 0)
                        {
                            int finalMove = y - move;

                            NumeberScript targetTile = tileManager.gridData[x, finalMove].tileNumber;
                            TileScript newTile = tileManager.gridData[x, finalMove].tileBase;

                            if (targetTile != null && targetTile.getValue() == playerTiley.getValue())
                            {
                                tileManager.gridData[x, y].tileNumber = null;

                                LeanTween.move(playerTiley.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                {
                                    int mergedValue = targetTile.getValue() * 2;
                                    targetTile.setValue(mergedValue);
                                    targetTile.UpdateValue();

                                    //tileManager.score += mergedValue;
                                    //tileManager.UpdateScoreValue();

                                    scorePoint += mergedValue;
                                    //OnScoreChanged?.Invoke(scorePoint);
                                    EventHolder.CallOnScoreUpdate(scorePoint);

                                    targetTile.UpdateTileColor();

                                    MonoBehaviour.Destroy(playerTiley.gameObject);

                                    LeanTween.scale(targetTile.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.1f).setOnComplete(() =>
                                    {
                                        LeanTween.scale(targetTile.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
                                    });
                                });

                                tileManager.gridData[x, finalMove].tileNumber = targetTile;
                                moveHappened = true;


                            }
                            else
                            {
                                tileManager.gridData[x, y].tileNumber = null;

                                LeanTween.move(playerTiley.gameObject, newTile.transform.position, 0.2f).setOnComplete(() =>
                                {
                                    playerTiley.transform.position = newTile.transform.position;
                                    playerTiley.transform.parent = newTile.transform;
                                    playerTiley.SetGridPlayerPosition(x, finalMove);
                                });

                                tileManager.gridData[x, finalMove].tileNumber = playerTiley;
                                moveHappened = true;

                            }

                        }
                    }
                }
            }

        }


        if (moveHappened)
        {
            LeanTween.delayedCall(0.1f, () =>
            {
                tileManager.SwitchState(tileManager.spawnState);
            });

        }

    }

}












