using UnityEngine;

namespace RunasDev.Core.Pooling
{
    /// <summary>
    /// Базовый класс для фабрик.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Factory<T> where T: Component
    {
        private readonly SetPool _pool;

        protected Factory(GameObject prefab)
        {
            _pool = new SetPool(prefab);
        }

        public virtual T Create()
        {
            return _pool.Spawn<T>(null);
        }

        public virtual void Destroy(T instance)
        {
            _pool.DeSpawn(instance.gameObject);
        }

    }
}