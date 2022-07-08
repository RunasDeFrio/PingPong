using System.Collections.Generic;
using RunasDev.Core.Pooling;
using Settings;
using UnityEngine;

public class BallFactory : Factory<Ball>
{
    private readonly BallInfo _ballInfo;
    private readonly SaveData _saveData;
    private readonly IReadOnlyList<Color> _colors;

    public BallFactory(BallInfo ballInfo, SaveData saveData, IReadOnlyList<Color> colors, GameObject ballPrefab) : base(ballPrefab)
    {
        _ballInfo = ballInfo;
        _saveData = saveData;
        _colors = colors;
    }

    public Ball Create(Vector2 startPosition, Vector2 speedDirection)
    {
        var ball = Create();
        var rb = ball.GetComponent<Rigidbody2D>();
        var transform = ball.transform;
        transform.position = startPosition;
        transform.localScale *= Random.Range(_ballInfo.minScale, _ballInfo.maxScale);
        rb.velocity = speedDirection * _ballInfo.speed;
        ball.SetColor(_colors[_saveData.BallColorIndex]);
        return ball;
    }
}
