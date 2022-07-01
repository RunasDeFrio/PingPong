using System.Collections.Generic;
using Levels;
using PingPongRacket;
using UnityEngine;

namespace RunasDev.Core.Pooling
{
    public class TimeLevelPrefab : MonoBehaviour
    {
        public BallTrigger[] triggers;
        public Vector2[] racketPos;
        public Vector2 ballPos;

        private TimeLevel _timeLevel;
        private IReadOnlyCollection<Racket> _rackets;

        public TimeLevel Level => _timeLevel;

        public IReadOnlyCollection<Racket> Rackets => _rackets;

        public void Construct(TimeLevel level, IReadOnlyCollection<Racket> rackets)
        {
            _rackets = rackets;
            _timeLevel = level;
        }
    }
}