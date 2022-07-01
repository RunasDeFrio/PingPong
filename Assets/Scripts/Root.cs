using System.Collections;
using System.Collections.Generic;
using Levels;
using PingPongRacket;
using UI;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private ProjectSettings _projectSettings;
    [SerializeField] private Camera gameCamera;

    [SerializeField] private RacketControlPanel controlPanel;

    void Start()
    {
        BallFactory ballFactory = new BallFactory(_projectSettings.BallPrefab);
        RacketFactory racketFactory = new RacketFactory(_projectSettings.RacketPrefab);
        TimeLevelBuilder timeLevelBuilder = new TimeLevelBuilder(_projectSettings.TimeLevelPrefab, new Records(), ballFactory, racketFactory);
        
        var timeLevel = timeLevelBuilder.Create();
        
        controlPanel.Construct(gameCamera, timeLevel.Rackets);
        
        timeLevel.Level.StartGame();
    }
}