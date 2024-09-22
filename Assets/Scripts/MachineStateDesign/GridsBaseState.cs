using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridsBaseState
{
    public abstract void EnterState(GridManagerState tileManager);

    public abstract void UpdateState(GridManagerState tileManager);
}
