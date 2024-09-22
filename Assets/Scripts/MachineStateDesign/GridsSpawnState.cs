using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridsSpawnState : GridsBaseState
{
    public override void EnterState(GridManagerState tileManager)
    {
        bool tileSpawned = false;

        while (!tileSpawned)
        {
            int x = Random.Range(0, tileManager.columns);
            int y = Random.Range(0, tileManager.rows);

            TileScript tile = tileManager.gridData[x, y].tileBase;
            Vector3 playerTilePosition = tile.transform.position;

            if (tile != null && tileManager.gridData[x, y].tileNumber == null)
            {
                NumeberScript playerTile = MonoBehaviour.Instantiate(tileManager.playerTilePrefab, playerTilePosition, Quaternion.identity);
                playerTile.transform.parent = tile.transform;

                playerTile.startValue();
                playerTile.SetGridPlayerPosition(x, y);

                tileManager.gridData[x, y].tileNumber = playerTile;

                tileSpawned = true;

                LeanTween.scale(playerTile.gameObject, new Vector3(0f, 0f, 0f), 0).setOnComplete(() =>
                {
                    LeanTween.scale(playerTile.gameObject, new Vector3(0.8f, 0.8f, 0.8f), 0.2f);
                });
            }
        }
        LeanTween.delayedCall(0.2f, () =>
        {
            tileManager.SwitchState(tileManager.winLoseState);
        });
    }

    public override void UpdateState(GridManagerState tileManager)
    {

    }
}

