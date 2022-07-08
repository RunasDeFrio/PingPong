using System;
using Levels;
using Settings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Панель таймера, показывает текущий результат и лучший.
    /// </summary>
    public class TopPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Button settingOpenButton;
        
        private TimeLevel _timeLevel;
        private Records _records;

        public void Open(Records records, TimeLevel timeLevel, Action onSettingButtonClick)
        {
            _records = records;
            _timeLevel = timeLevel;
            settingOpenButton.onClick.AddListener(onSettingButtonClick.Invoke);
        }

        private void Update()
        {
            if (_timeLevel.IsStart)
                text.text = $"{_timeLevel.ResultTime:F1} : {_records.lastRecordTime:F1}";
        }
    }
}