using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    /// <summary>
    /// Provides API to Request PoolObjects from ObjectPools.
    /// </summary>
    [AddComponentMenu("Object Pooling/Object Pool Manager")]
    [DisallowMultipleComponent]
    public class ObjectPoolManager : MonoBehaviour
    {
        #region Fields and Properties
        [Tooltip("The PoolObject prefabs this manager is responsible for.")]
        [SerializeField] private PoolObject[] _prefabs = { };

        private Dictionary<string, ObjectPool> _pools = new Dictionary<string, ObjectPool>();
        #endregion

        #region Unity Events
        private void Awake()
        {
            foreach (PoolObject prefab in _prefabs)
            {
                if (_pools.ContainsKey(prefab.name)) continue;
                GameObject poolGameObject = new GameObject($"{prefab.name} Pool");
                poolGameObject.transform.SetParent(transform);
                ObjectPool pool = poolGameObject.AddComponent<ObjectPool>();
                pool.SetPrefab(prefab);
                _pools.Add(prefab.name, pool);
            }
        }

        private void Update()
        {
            foreach (KeyValuePair<string, ObjectPool> pool in _pools)
            {
                pool.Value.CheckForInactiveObjects();
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Spawns an instance of the given prefab.
        /// </summary>
        /// <param name="prefabName"></param>
        /// <returns></returns>
        public PoolObject Spawn(string prefabName)
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn();
        }

        /// <summary>
        /// Spawns a component on an instance of the given prefab.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <returns></returns>
        public T Spawn<T>(string prefabName) where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn<T>();
        }

        /// <summary>
        /// Spawns an instance of the given prefab.
        /// Sets the instance's transform parent.
        /// </summary>
        /// <param name="prefabName"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public PoolObject Spawn(string prefabName, Transform parent)
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn(parent);
        }

        /// <summary>
        /// Spawns a component on an instance of the given prefab.
        /// Sets the instance's transform parent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public T Spawn<T>(string prefabName, Transform parent) where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn<T>(parent);
        }

        /// <summary>
        /// Spawns an instance of the given prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position.
        /// </summary>
        /// <param name="prefabName"></param>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public PoolObject Spawn(string prefabName, Transform parent, Vector3 position)
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn(parent, position);
        }

        /// <summary>
        /// Spawns a component on an instance of the given prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Spawn<T>(string prefabName, Transform parent, Vector3 position) where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn<T>(parent, position);
        }

        /// <summary>
        /// Spawns an instance of the given prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <param name="prefabName"></param>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public PoolObject Spawn(string prefabName, Transform parent, Vector3 position, Vector3 rotation)
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn(parent, position, rotation);
        }

        /// <summary>
        /// Spawns a component on an instance of the given prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public T Spawn<T>(string prefabName, Transform parent, Vector3 position, Vector3 rotation) where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn<T>(parent, position, rotation);
        }

        /// <summary>
        /// Spawns an instance of the given prefab.
        /// Sets the instance's position.
        /// </summary>
        /// <param name="prefabName"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public PoolObject Spawn(string prefabName, Vector3 position)
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn(position);
        }

        /// <summary>
        /// Spawns a component on an instance of the given prefab.
        /// Sets the instance's position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Spawn<T>(string prefabName, Vector3 position) where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn<T>(position);
        }

        /// <summary>
        /// Spawns an instance of the given prefab.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <param name="prefabName"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public PoolObject Spawn(string prefabName, Vector3 position, Vector3 rotation)
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn(position, rotation);
        }

        /// <summary>
        /// Spawns a component on an instance of the given prefab.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefabName"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public T Spawn<T>(string prefabName, Vector3 position, Vector3 rotation) where T : MonoBehaviour
        {
            if (!_pools.ContainsKey(prefabName)) return null;
            return _pools[prefabName].Spawn<T>(position, rotation);
        }
        #endregion
    }
}