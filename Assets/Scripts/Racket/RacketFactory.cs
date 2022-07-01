using RunasDev.Core.Pooling;
using UnityEngine;

namespace PingPongRacket
{
    public class RacketFactory : Factory<Racket>
    {
        public RacketFactory(GameObject ballPrefab) : base(ballPrefab)
        {
        }

        public  Racket Create(Vector2 position)
        {
            var racket = base.Create();
            racket.transform.position = position;
            return racket;
        }
    }
}