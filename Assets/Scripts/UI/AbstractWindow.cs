using System;
using System.Collections.Generic;
using UnityEngine;

namespace RunasDev.UI
{
    /// <summary>
    /// Базовый класс для окон.
    /// </summary>
    public abstract class AbstractWindow : MonoBehaviour
    {
        private bool _isOpen;
        public bool IsOpen => _isOpen;

        protected void BaseOpen()
        {
            if (IsOpen)
                return;

            _isOpen = true;
            OnOpen();
        }
        
        public void Close()
        {
            if (!_isOpen)
                return;

            _isOpen = false;
            OnClose();
        }

        protected virtual void OnOpen()
        {
            gameObject.SetActive(true);
        }

        protected virtual void OnClose()
        {
            gameObject.SetActive(false);
        }
    }
}