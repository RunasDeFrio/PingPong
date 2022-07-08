using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public Records Records;
    public int BallColorIndex;
    
    public SaveData()
    {
        BallColorIndex = 0;
        Records = new Records();
    }
}