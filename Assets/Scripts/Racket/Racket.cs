using System;
using UnityEngine;

namespace PingPongRacket
{
    /// <summary>
    /// Класс ракетки, управляет перемещением.
    /// </summary>
    public class Racket : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D rigidbody;
        
        public Vector2 TargetPosition { get; set; }
        
        public Vector2 Position => transform.position;

        public void FixedUpdate()
        {
            rigidbody.velocity =  Vector2.ClampMagnitude(TargetPosition - rigidbody.position, 5);
        }
    }
}