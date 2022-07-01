using System.Security.Cryptography.X509Certificates;
using RunasDev.UI;
using UnityEngine;

namespace UI
{
    public class SettingsWindow : AbstractWindow
    {
        private SaveData _saveData;
        
        public void Open(SaveData saveData)
        {
            _saveData = saveData;
            BaseOpen();
            
        }
    }
}