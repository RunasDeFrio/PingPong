using System;
using UnityEngine;

/// <summary>
/// Триггер бортика мяча.
/// </summary>
public class BallTrigger : MonoBehaviour
{
    public event Action<Ball> OnBallEnterTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            OnBallEnterTrigger?.Invoke(ball);
        }
    }

    private void OnDisable()
    {
        OnBallEnterTrigger = null;
    }
}