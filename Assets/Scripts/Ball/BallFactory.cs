using RunasDev.Core.Pooling;
using Settings;
using UnityEngine;

public class BallFactory : Factory<Ball>
{
    private readonly BallInfo _ballInfo;
    private readonly Color? _color;

    public BallFactory(BallInfo ballInfo, ref Color color, GameObject ballPrefab) : base(ballPrefab)
    {
        _ballInfo = ballInfo;
        _color = color;
    }

    public Ball Create(Vector2 startPosition, Vector2 speedDirection)
    {
        var ball = Create();
        var rb = ball.GetComponent<Rigidbody2D>();
        var transform = ball.transform;
        transform.position = startPosition;
        transform.localScale *= Random.Range(_ballInfo.minScale, _ballInfo.maxScale);
        rb.velocity = speedDirection * _ballInfo.speed;
        return ball;
    }
}
