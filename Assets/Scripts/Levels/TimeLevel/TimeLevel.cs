using System;
using System.Collections.Generic;
using PingPongRacket;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    public class TimeLevel : ILevel
    {
        private readonly Records _records;
        private readonly BallFactory _ballFactory;
        private readonly RacketFactory _racketFactory;
        private readonly BallTrigger[] _ballTriggers;
        private readonly Vector2 _ballPosition;
        
        private float _startTime;
        private Ball _ball;

        public TimeLevel(Records records, BallFactory ballFactory, RacketFactory racketFactory, BallTrigger[] ballTriggers, Vector2 ballPosition)
        {
            _records = records;
            _ballFactory = ballFactory;
            _racketFactory = racketFactory;
            _ballTriggers = ballTriggers;
            _ballPosition = ballPosition;
        }
        
        public event Action OnGameStart;
        public event Action OnGameOver;

        public void StartGame()
        {
            _startTime = Time.time;
            OnGameStart?.Invoke();
        
            foreach (var ballTrigger in _ballTriggers)
            {
                ballTrigger.OnBallEnterTrigger += OnBallEnterTrigger;
            }

            _ball = _ballFactory.Create(new BallInfo(_ballPosition, Random.insideUnitCircle.normalized * 10, 1f, Color.black));
        }

        private void OnBallEnterTrigger(Ball ball)
        {
            GameOver();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
            var result = Time.time - _startTime;
            _ballFactory.Destroy(_ball);
            foreach (var ballTrigger in _ballTriggers)
            {
                ballTrigger.OnBallEnterTrigger -= OnBallEnterTrigger;
            }
            StartGame();
        }
    }
}