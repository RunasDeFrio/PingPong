using System;
using System.Collections;
using System.Collections.Generic;
using Levels;
using PingPongRacket;
using RunasDev.Core.SaveSystem;
using Settings;
using UI;
using UnityEngine;

/// <summary>
/// Основной класс, где происходит основная сборка классов.
/// </summary>
public class Root : MonoBehaviour
{
    [SerializeField] private ProjectSettings _projectSettings;
    [SerializeField] private Camera gameCamera;
    [SerializeField] private TimerPanel timerPanel;
    [SerializeField] private RacketControlPanel controlPanel;

    private Saver _fileSaver;
    private SaveData _saveData;

    void Start()
    {
        _fileSaver = new Saver();
        _saveData = _fileSaver.LoadAndParse<SaveData>() ?? new SaveData();

        BallFactory ballFactory = new BallFactory(_projectSettings.BallInfo, ref _saveData.BallColor, _projectSettings.BallPrefab);
        RacketFactory racketFactory = new RacketFactory(_projectSettings.RacketPrefab);
        TimeLevelBuilder timeLevelBuilder = new TimeLevelBuilder(_projectSettings.TimeLevelPrefab, _saveData.Records,
            ballFactory, racketFactory);

        var timeLevel = timeLevelBuilder.Create();

        controlPanel.Construct(gameCamera, timeLevel.Rackets);
        timerPanel.Open(_saveData.Records, timeLevel.Level);

        timeLevel.Level.StartGame();
    }

    private void OnDisable()
    {
        _fileSaver?.Save(_saveData);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        _fileSaver?.Save(_saveData);
    }
}