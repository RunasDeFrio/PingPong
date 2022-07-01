using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Records Records;
    public Color BallColor;
    
    public SaveData()
    {
        BallColor = Color.white;
        Records = new Records();
    }
}