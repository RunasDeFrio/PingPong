using System;
using System.Collections.Generic;
using PingPongRacket;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class RacketControlPanel : MonoBehaviour, IDragHandler
    {
        private IReadOnlyCollection<Racket> _rackets;
        private Camera _gameCamera;

        public void Construct(Camera gameCamera, IReadOnlyCollection<Racket> racket)
        {
            _gameCamera = gameCamera;
            _rackets = racket;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            foreach (var racket in _rackets)
            {
                racket.TargetPosition = new Vector2(_gameCamera.ScreenToWorldPoint(eventData.position).x, racket.Position.y);
            }
        }
    }
}