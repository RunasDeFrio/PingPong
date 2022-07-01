using System;
using Levels;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private TimeLevel _timeLevel;
        private Records _records;

        public void Open(Records records, TimeLevel timeLevel)
        {
            _records = records;
            _timeLevel = timeLevel;
        }

        private void Update()
        {
            if (_timeLevel.IsStart)
                text.text = $"{_timeLevel.ResultTime.ToString("F1")} : {_records.lastRecordTime.ToString("F1")}";
        }
    }
}