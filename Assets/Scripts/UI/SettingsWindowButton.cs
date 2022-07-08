using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsWindowButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        
        public event Action<int> OnClick;

        public void Construct(Color color, int index)
        {
            _button.onClick.AddListener(() => OnClick?.Invoke(index));
            _image.color = color;
        }
        
        public void DeConstruct()
        {
            OnClick = null;
            _button.onClick.RemoveAllListeners();
        }
    }
}