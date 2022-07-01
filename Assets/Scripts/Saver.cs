using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace RunasDev.Core.SaveSystem
{
    /// <summary>
    /// Сохраняет и парсит данные в нужный файл.
    /// </summary>
    public class Saver
    {
        private readonly string _savePath;
        private string _dataPath;


        public Saver(string fileName = "save.json")
        {
            _dataPath = Application.persistentDataPath + "/SaveData";
            _savePath = _dataPath + '/' + fileName;
        }

        public T LoadAndParse<T>()
        {
            return JsonUtility.FromJson<T>(Load());
        }

        public string Load()
        {
            try
            {
                if (Directory.Exists(_dataPath))
                {
                    if (File.Exists(_savePath))
                        return File.ReadAllText(_savePath);
                }
                else
                {
                    Directory.CreateDirectory(_dataPath);
                }
            }
            catch (Exception exception)
            {
                Debug.LogError(exception);
            }

            return null;
        }

        public void Save(object obj)
        {
            if (!Directory.Exists(_dataPath))
                Directory.CreateDirectory(_dataPath);

            File.WriteAllText(_savePath, JsonUtility.ToJson(obj));
        }
    }
}