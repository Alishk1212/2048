using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumeberScript : MonoBehaviour
{
    public Vector2Int gridPlayerPosition;

    public TMP_Text numberToText;

    private int value;
    private int moveP;
    void Start()
    {
        int newValue = getValue();
        setValue(newValue);
    }

    public void SetGridPlayerPosition(int x, int y)
    {
        gridPlayerPosition = new Vector2Int(x, y);
    }

    public Vector2Int GetGridPlayerPosition()
    {
        return gridPlayerPosition;
    }

    public void UpdateValue()
    {
        numberToText.text = value.ToString();
    }
    public void setValue(int newValue)
    {
        value = newValue;
        UpdateValue();
    }
    public int getValue()
    {
        return value;
    }
    public void setMove(int move)
    {
        moveP = move;
    }
    public int getMove()
    {
        return moveP;
    }
    public int startValue()
    {
        float x = Random.Range(0f , 1f);
        if (x <= 0.9f)
        {
            value = 2;
            return value;
        }
        else
        {
            value = 4;
            return value;
        }
    }
    public void UpdateTileColor()
    {

    }
}
