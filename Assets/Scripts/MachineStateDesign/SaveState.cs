using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveState : GridsBaseState
{
    List<Vector2Int> TilePositions = new List<Vector2Int>();
    List<int> TileValues = new List<int>();
    public override void EnterState(GridManagerState tileManager)
    {


        if (!tileManager.canUndo)
        {
            TilePositions.Clear();
            TileValues.Clear();
            for (int x = 0; x < tileManager.columns; x++)
            {
                for (int y = 0; y < tileManager.rows; y++)
                {
                    if (tileManager.gridData[x, y].tileNumber != null)
                    {
                        NumeberScript playerTile = tileManager.gridData[x, y].tileNumber;

                        TilePositions.Add(new Vector2Int(x, y));
                        TileValues.Add(playerTile.getValue());
                    }
                }
            }
        }

        else if (tileManager.canUndo)
        {

            for (int x = 0; x < tileManager.columns; x++)
            {
                for (int y = 0; y < tileManager.rows; y++)
                {
                    if (tileManager.gridData[x, y].tileNumber != null)
                    {
                        NumeberScript playerTile = tileManager.gridData[x, y].tileNumber;

                        MonoBehaviour.Destroy(playerTile.gameObject);

                        tileManager.gridData[x, y].tileNumber = null;
                    }
                }
            }

            tileManager.canUndo = false;

            for (int i = 0; i < TilePositions.Count; i++)
            {
                Vector2Int tilePos = TilePositions[i];

                TileScript tile = tileManager.gridData[tilePos.x, tilePos.y].tileBase;

                Vector3 playerTilePosition = tile.transform.position;

                if (tile != null && tileManager.gridData[tilePos.x, tilePos.y].tileNumber == null)
                {
                    NumeberScript playerTile = MonoBehaviour.Instantiate(tileManager.playerTilePrefab, playerTilePosition, Quaternion.identity);

                    playerTile.transform.parent = tile.transform;

                    playerTile.setValue(TileValues[i]);

                    playerTile.SetGridPlayerPosition(tilePos.x, tilePos.y);

                    tileManager.gridData[tilePos.x, tilePos.y].tileNumber = playerTile;

                    LeanTween.scale(playerTile.gameObject, new Vector3(0f, 0f, 0f), 0).setOnComplete(() =>
                    {
                        LeanTween.scale(playerTile.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.2f);
                    });
                }
            }

            tileManager.SwitchState(tileManager.movementState);
        }
    }

    public override void UpdateState(GridManagerState tileManager)
    {

    }
}
