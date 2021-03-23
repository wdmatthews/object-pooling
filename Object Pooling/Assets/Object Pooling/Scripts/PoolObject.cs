using UnityEngine;

namespace ObjectPooling
{
    /// <summary>
    /// The component that marks a GameObject for use in an ObjectPool.
    /// </summary>
    [AddComponentMenu("Object Pooling/Pool Object")]
    [DisallowMultipleComponent]
    public class PoolObject : MonoBehaviour
    {
        #region Fields and Properties
        public bool IsActive { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Activates the object and its GameObject.
        /// Used by ObjectPool only.
        /// </summary>
        public void Initialize() => SetActive(true);

        /// <summary>
        /// Activates the object and its GameObject.
        /// Sets the transform parent of the object.
        /// Used by ObjectPool only.
        /// </summary>
        /// <param name="parent"></param>
        public void Initialize(Transform parent)
        {
            transform.SetParent(parent);
            SetActive(true);
        }

        /// <summary>
        /// Activates the object and its GameObject.
        /// Sets the transform parent of the object.
        /// Sets the position of the object.
        /// Used by ObjectPool only.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        public void Initialize(Transform parent, Vector3 position)
        {
            transform.SetParent(parent);
            transform.position = position;
            SetActive(true);
        }

        /// <summary>
        /// Activates the object and its GameObject.
        /// Sets the transform parent of the object.
        /// Sets the position and rotation of the object.
        /// Used by ObjectPool only.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="position"></param>
        /// <param name="rotation">The new eulerAngles for the object.</param>
        public void Initialize(Transform parent, Vector3 position, Vector3 rotation)
        {
            transform.SetParent(parent);
            transform.position = position;
            transform.eulerAngles = rotation;
            SetActive(true);
        }

        /// <summary>
        /// Activates the object and its GameObject.
        /// Sets the position of the object.
        /// Used by ObjectPool only.
        /// </summary>
        /// <param name="position"></param>
        public void Initialize(Vector3 position)
        {
            transform.position = position;
            SetActive(true);
        }

        /// <summary>
        /// Activates the object and its GameObject.
        /// Sets the position and rotation of the object.
        /// Used by ObjectPool only.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation">The new eulerAngles for the object.</param>
        public void Initialize(Vector3 position, Vector3 rotation)
        {
            transform.position = position;
            transform.eulerAngles = rotation;
            SetActive(true);
        }

        /// <summary>
        /// Deactivates the object and its GameObject.
        /// </summary>
        public void Despawn() => SetActive(false);
        #endregion

        #region Private Methods
        /// <summary>
        /// Sets the active state of the object.
        /// </summary>
        /// <param name="isActive"></param>
        private void SetActive(bool isActive)
        {
            IsActive = isActive;
            gameObject.SetActive(isActive);
        }
        #endregion
    }
}