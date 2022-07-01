using System.Collections.Generic;
using PingPongRacket;
using RunasDev.Core.Pooling;
using UnityEngine;

namespace Levels
{
    public class TimeLevelBuilder : Factory<TimeLevelPrefab>
    {
        private readonly TimeLevelPrefab _timeLevelData;
        private readonly Records _records;
        private readonly BallFactory _ballFactory;
        private readonly RacketFactory _racketFactory;

        public TimeLevelBuilder(GameObject timeLevelPrefab, Records records, BallFactory ballFactory, RacketFactory racketFactory) : base(timeLevelPrefab)
        {
            _records = records;
            _ballFactory = ballFactory;
            _racketFactory = racketFactory;
        }

        public override TimeLevelPrefab Create()
        {
            var timeLevelPrefab = base.Create();

            List<Racket> rackets = new List<Racket>(timeLevelPrefab.racketPos.Length);
            foreach (var position in timeLevelPrefab.racketPos)
            {
                rackets.Add(_racketFactory.Create(position));
            }
            
            var timeLevel = new TimeLevel(_records, _ballFactory, _racketFactory, timeLevelPrefab.triggers, timeLevelPrefab.ballPos);
            timeLevelPrefab.Construct(timeLevel, rackets);
            return timeLevelPrefab;
        }

        public override void Destroy(TimeLevelPrefab instance)
        {
            foreach (var racket in instance.Rackets)
            {
                _racketFactory.Destroy(racket);
            }
            base.Destroy(instance);
        }
    }
}