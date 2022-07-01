using RunasDev.Core.Pooling;
using UnityEngine;

public class BallFactory : Factory<Ball>
{
    public BallFactory(GameObject ballPrefab) : base(ballPrefab)
    {
    }

    public Ball Create(BallInfo ballInfo)
    {
        var ball = Create();
        var rb = ball.GetComponent<Rigidbody2D>();
        var transform = ball.transform;
        transform.position = ballInfo.StartPosition;
        transform.localScale *= ballInfo.SizeScale;
        rb.velocity = ballInfo.StartSpeed;
        return ball;
    }
}
