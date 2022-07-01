using System;
using System.Collections.Generic;
using PingPongRacket;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    /// <summary>
    /// Класс основной логики уровня с таймером.
    /// </summary>
    public class TimeLevel : ILevel
    {
        private readonly Records _records;
        private readonly BallFactory _ballFactory;
        private readonly RacketFactory _racketFactory;
        private readonly BallTrigger[] _ballTriggers;
        private readonly Vector2 _ballPosition;
        
        private float _time;
        private Ball _ball;
        private bool _isStart;

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

        public float ResultTime => Time.time - _time;

        public bool IsStart => _isStart;

        public void StartGame()
        {
            _time = Time.time;
        
            foreach (var ballTrigger in _ballTriggers)
            {
                ballTrigger.OnBallEnterTrigger += OnBallEnterTrigger;
            }

            _ball = _ballFactory.Create(_ballPosition, Random.insideUnitCircle.normalized);
            _isStart = true;
            OnGameStart?.Invoke();
        }

        private void OnBallEnterTrigger(Ball ball)
        {
            GameOver();
        }

        public void GameOver()
        {
            OnGameOver?.Invoke();
            _isStart = false;
            var result = ResultTime;
            if (_records.lastRecordTime < result)
            {
                _records.lastRecordTime = result;
            }
            
            _ballFactory.Destroy(_ball);
            foreach (var ballTrigger in _ballTriggers)
            {
                ballTrigger.OnBallEnterTrigger -= OnBallEnterTrigger;
            }
            StartGame();
        }
    }
}