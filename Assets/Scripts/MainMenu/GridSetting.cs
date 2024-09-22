using UnityEngine;

public class GridSetting : MonoBehaviour
{
    private static GridSetting instance = null;
    public static GridSetting Instance
    {
        get { return instance; }
        private set { instance = value; }
    }

    public int GridColumns;
    public int GridRows;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetGridSize(int gridColumns, int gridRows)
    {
        GridColumns = gridColumns;
        GridRows = gridRows;
    }
}
