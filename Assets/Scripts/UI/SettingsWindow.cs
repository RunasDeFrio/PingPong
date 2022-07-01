using System.Security.Cryptography.X509Certificates;
using RunasDev.UI;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Окно настройки с выбором цвета.
    /// Пока в процессе :)
    /// </summary>
    public class SettingsWindow : AbstractWindow
    {
        private SaveData _saveData;

        private FlexibleColorPicker _colorPicker;
        
        public void Open(SaveData saveData)
        {
            _saveData = saveData;
            BaseOpen();
            _colorPicker.color = _saveData.BallColor;
        }

        protected override void OnClose()
        {
            _saveData.BallColor = _colorPicker.color;

            base.OnClose();
        }
    }
}