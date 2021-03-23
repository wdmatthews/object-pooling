using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    /// <summary>
    /// Stores and manages related PoolObjects.
    /// Do not create an instance of this manually in the inspector.
    /// This class is only for use by the ObjectPoolManager.
    /// </summary>
    [AddComponentMenu("Object Pooling/Object Pool")]
    [DisallowMultipleComponent]
    public class ObjectPool : MonoBehaviour
    {
        #region Fields and Properties
        private PoolObject _prefab = null;
        private List<PoolObject> _activeObjects = new List<PoolObject>();
        private List<PoolObject> _inactiveObjects = new List<PoolObject>();
        #endregion

        #region Public Methods
        /// <summary>
        /// Assigns a prefab to this pool.
        /// </summary>
        /// <param name="prefab">The prefab to use for this pool.</param>
        public void SetPrefab(PoolObject prefab) => _prefab = prefab;

        /// <summary>
        /// Checks if there are any newly inactive objects.
        /// If so, those objects are moved to the inactive list.
        /// </summary>
        public void CheckForInactiveObjects()
        {
            int activeCount = _activeObjects.Count;
            for (int i = activeCount - 1; i >= 0; i--)
            {
                PoolObject poolObject = _activeObjects[i];
                if (poolObject.IsActive) continue;
                _inactiveObjects.Add(poolObject);
                _activeObjects.RemoveAt(i);
            }
        }

        /// <summary>
        /// Spawns an instance of this pool's prefab.
        /// </summary>
        /// <returns></returns>
        public PoolObject Spawn()
        {
            PoolObject poolObject = GetObject();
            poolObject.Initialize();
            return poolObject;
        }

        /// <summary>
        /// Spawns a component on an instance of this pool's prefab.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Spawn<T>() where T : MonoBehaviour
        {
            return Spawn().GetComponent<T>();
        }

        /// <summary>
        /// Spawns an instance of this pool's prefab.
        /// Sets the instance's transform parent.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public PoolObject Spawn(Transform parent)
        {
            PoolObject poolObject = GetObject();
            poolObject.Initialize(parent);
            return poolObject;
        }

        /// <summary>
        /// Spawns a component on an instance of this pool's prefab.
        /// Sets the instance's transform parent.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public T Spawn<T>(Transform parent) where T : MonoBehaviour
        {
            return Spawn(parent).GetComponent<T>();
        }

        /// <summary>
        /// Spawns an instance of this pool's prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public PoolObject Spawn(Transform parent, Vector3 position)
        {
            PoolObject poolObject = GetObject();
            poolObject.Initialize(parent, position);
            return poolObject;
        }

        /// <summary>
        /// Spawns a component on an instance of this pool's prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Spawn<T>(Transform parent, Vector3 position) where T : MonoBehaviour
        {
            return Spawn(parent, position).GetComponent<T>();
        }

        /// <summary>
        /// Spawns an instance of this pool's prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <param name="rotation">The new eulerAngles for the object.</param>
        /// <returns></returns>
        public PoolObject Spawn(Transform parent, Vector3 position, Vector3 rotation)
        {
            PoolObject poolObject = GetObject();
            poolObject.Initialize(parent, position, rotation);
            return poolObject;
        }

        /// <summary>
        /// Spawns a component on an instance of this pool's prefab.
        /// Sets the instance's transform parent.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <param name="rotation">The new eulerAngles for the object.</param>
        /// <returns></returns>
        public T Spawn<T>(Transform parent, Vector3 position, Vector3 rotation) where T : MonoBehaviour
        {
            return Spawn(parent, position, rotation).GetComponent<T>();
        }

        /// <summary>
        /// Spawns an instance of this pool's prefab.
        /// Sets the instance's position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public PoolObject Spawn(Vector3 position)
        {
            PoolObject poolObject = GetObject();
            poolObject.Initialize(position);
            return poolObject;
        }

        /// <summary>
        /// Spawns a component on an instance of this pool's prefab.
        /// Sets the instance's position.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <returns></returns>
        public T Spawn<T>(Vector3 position) where T : MonoBehaviour
        {
            return Spawn(position).GetComponent<T>();
        }

        /// <summary>
        /// Spawns an instance of this pool's prefab.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation">The new eulerAngles for the object.</param>
        /// <returns></returns>
        public PoolObject Spawn(Vector3 position, Vector3 rotation)
        {
            PoolObject poolObject = GetObject();
            poolObject.Initialize(position, rotation);
            return poolObject;
        }

        /// <summary>
        /// Spawns a component on an instance of this pool's prefab.
        /// Sets the instance's position and rotation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="position"></param>
        /// <param name="rotation">The new eulerAngles for the object.</param>
        /// <returns></returns>
        public T Spawn<T>(Vector3 position, Vector3 rotation) where T : MonoBehaviour
        {
            return Spawn(position, rotation).GetComponent<T>();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns a new instance of the prefab or an inactive instance if available.
        /// </summary>
        /// <returns></returns>
        private PoolObject GetObject()
        {
            PoolObject poolObject = null;
            int inactiveCount = _inactiveObjects.Count;

            if (inactiveCount > 0)
            {
                poolObject = _inactiveObjects[inactiveCount - 1];
                _inactiveObjects.RemoveAt(inactiveCount - 1);
            }
            else
            {
                poolObject = Instantiate(_prefab, transform);
                poolObject.name = $"{_prefab.name} Instance";
            }

            _activeObjects.Add(poolObject);
            return poolObject;
        }
        #endregion
    }
}