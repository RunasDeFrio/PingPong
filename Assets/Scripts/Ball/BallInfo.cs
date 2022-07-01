using UnityEngine;

public class BallInfo
{
    public Vector2 StartPosition;
    public Vector2 StartSpeed;
    public float SizeScale;
    public Color Color;

    public BallInfo(Vector2 startPosition, Vector2 startSpeed, float sizeScale, Color color)
    {
        StartPosition = startPosition;
        StartSpeed = startSpeed;
        SizeScale = sizeScale;
        Color = color;
    }
}