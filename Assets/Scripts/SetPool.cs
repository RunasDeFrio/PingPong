using System.Collections.Generic;
using UnityEngine;

namespace RunasDev.Core.Pooling
{
    public class SetPool
    {
        private readonly GameObject _spawnGameObject;

        /// <summary>
        /// Пулл удалённых объектов
        /// </summary>
        private readonly Stack<GameObject> _despawnPool = new();

        /// <summary>
        /// Множество активных объектов.
        /// </summary>
        private readonly HashSet<GameObject> _setActiveObjects = new();

        
        public SetPool(GameObject spawnGameObject)
        {
            _spawnGameObject = spawnGameObject;
        }

        /// <summary>
        /// Множество активных объектов.
        /// </summary>
        public IReadOnlyCollection<GameObject> SetActiveObjects => _setActiveObjects;

        /// <summary>
        /// Создать или вытянуть из пулла копию префаба.
        /// </summary>
        /// <returns>Созданная или вытянутая копия префаба, прикреплённая к владельцу </returns>
        public GameObject Spawn(Transform transform, bool worldPositionStays = false)
        {
            GameObject instance;
            if (_despawnPool.Count > 0)
            {
                instance = _despawnPool.Pop();
                instance.transform.SetParent(transform);
                instance.transform.localPosition = Vector3.zero;
                instance.transform.localRotation = Quaternion.identity;
                instance.transform.localScale = Vector3.one;
            }
            else
            {
                instance = Object.Instantiate(_spawnGameObject, transform);
            }
            instance.SetActive(true);
            _setActiveObjects.Add(instance);
            return instance;
        }

        public T Spawn<T>(Transform transform, bool worldPositionStays = false)
        {
            GameObject go = Spawn(transform, worldPositionStays);
            var component = go.GetComponent<T>();
            
            if(component == null)
                DeSpawn(go);
            return component;
        }
        
        
        public void Attach(GameObject gameObject, bool deSpawn = true)
        {
            if (deSpawn)
            {
                gameObject.SetActive(false);
                _despawnPool.Push(gameObject);
            }
            else
            {
                gameObject.SetActive(true);
                _setActiveObjects.Add(gameObject);
            }
        }

        public void DeSpawn(GameObject gameObject)
        {
            if (_setActiveObjects.Contains(gameObject))
            {
                _despawnPool.Push(gameObject);
                _setActiveObjects.Remove(gameObject);
                gameObject.SetActive(false);
            }
        }

        public void DeSpawnAll()
        {
            foreach (var gameObject in _setActiveObjects)
            {
                gameObject.SetActive(false);
                _despawnPool.Push(gameObject);
            }

            _setActiveObjects.Clear();
        }
    }
}