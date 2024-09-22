using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GridsCreatorState : GridsBaseState
{
    public override void EnterState(GridManagerState tileManager)
    {
        tileManager.gridData = new GridData[tileManager.columns, tileManager.rows];

        for (int x = 0; x < tileManager.columns; x++)
        {
            for (int y = 0; y < tileManager.rows; y++)
            {
                tileManager.gridData[x, y] = new GridData();

                Vector3 newTile = new Vector3((x - 1.5f) * 1.1f, (y - 1.5f) * 1.1f, 0);

                TileScript mainTile = MonoBehaviour.Instantiate(tileManager.tilePrefab, newTile, Quaternion.identity, tileManager.PrefabsInstantiatePlace);
                mainTile.SetGridPosition(x, y);

                tileManager.gridData[x, y].tileBase = mainTile;

                tileManager.gridData[x, y].tileNumber = null;

                LeanTween.scale(mainTile.gameObject, new Vector3(0f, 0f, 0f), 0f).setEaseInCubic().setOnComplete(() =>
                    {
                        LeanTween.scale(mainTile.gameObject, new Vector3(1f, 1f, 1f), 0.4f);
                    });

            }
        }

        tileManager.SwitchState(tileManager.detectEmptyGridsState);

    }

    public override void UpdateState(GridManagerState tileManager)
    {


    }
}
