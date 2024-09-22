using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GridsDetectEmptyGridsState : GridsBaseState
{
    public override void EnterState(GridManagerState tileManager)
    {
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
        tileManager.SwitchState(tileManager.spawnState);
        tileManager.SwitchState(tileManager.spawnState);
    }

    public override void UpdateState(GridManagerState tileManager)
    {

    }
}
