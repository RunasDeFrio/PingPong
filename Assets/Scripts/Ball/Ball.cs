using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    public void SetColor(Color color)
    {
        sprite.color = color;
    }
}