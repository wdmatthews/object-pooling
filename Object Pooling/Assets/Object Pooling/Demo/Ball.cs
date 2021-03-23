using UnityEngine;

namespace ObjectPooling.Demo
{
    /// <summary>
    /// Demonstrates how to use the object pooling system with a pooled object.
    /// </summary>
    [AddComponentMenu("Object Pooling/Demo/Ball")]
    [DisallowMultipleComponent]
    public class Ball : MonoBehaviour
    {
        #region Fields and Properties
        [SerializeField] private PoolObject _poolObject = null;
        [SerializeField] private Rigidbody2D _rigidbody = null;
        [SerializeField] private SpriteRenderer _renderer = null;
        #endregion

        #region Unity Events
        private void Update()
        {
            // If the ball is below the ground, recycle it.
            if (transform.position.y < -5.5f) _poolObject.Despawn();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Called immediately after PoolObject.Initialize().
        /// </summary>
        /// <param name="color"></param>
        /// <param name="xVelocity"></param>
        public void Initialize(Color color, float xVelocity)
        {
            _rigidbody.velocity = new Vector2(xVelocity, 0);
            _renderer.color = color;
        }
        #endregion
    }
}