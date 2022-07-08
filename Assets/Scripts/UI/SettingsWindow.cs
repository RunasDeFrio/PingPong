using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RunasDev.Core.Pooling;
using RunasDev.UI;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Окно настройки с выбором цвета.
    /// </summary>
    public class SettingsWindow : AbstractWindow
    {
        [SerializeField] private SettingsWindowButton imagePrefab;

        [SerializeField] private Transform spawnButtonTransform;

        [SerializeField] private Button closeButton;

        private SaveData _saveData;

        private SetPool _colorPool;

        private List<SettingsWindowButton> _buttons;


        public void Open(SaveData saveData, ProjectSettings projectSettings, TimeLevelPrefab timeLevelPrefab)
        {
            _saveData = saveData;
            _colorPool ??= new SetPool(imagePrefab.gameObject);
            _buttons ??= new List<SettingsWindowButton>();

            BaseOpen();

            for (var i = 0; i < projectSettings.Colors.Count; i++)
            {
                var color = projectSettings.Colors[i];
                var button = _colorPool.Spawn<SettingsWindowButton>(spawnButtonTransform);
                button.Construct(color, i);
                _buttons.Add(button);
                button.OnClick += index =>
                {
                    _saveData.BallColorIndex = index;
                    if (timeLevelPrefab.Level.Ball != null) 
                        timeLevelPrefab.Level.Ball.SetColor(color);
                    Close();
                };
            }

            closeButton.onClick.AddListener(Close);
        }

        protected override void OnClose()
        {
            _colorPool.DeSpawnAll();
            foreach (var button in _buttons)
            {
                button.DeConstruct();
            }

            closeButton.onClick.RemoveAllListeners();
            _buttons.Clear();
            base.OnClose();
        }
    }
}