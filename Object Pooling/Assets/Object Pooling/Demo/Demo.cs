using UnityEngine;

namespace ObjectPooling.Demo
{
    /// <summary>
    /// Demonstrates how to use the object pooling system.
    /// </summary>
    [AddComponentMenu("Object Pooling/Demo/Demo")]
    [DisallowMultipleComponent]
    public class Demo : MonoBehaviour
    {
        #region Fields and Properties
        [SerializeField] private ObjectPoolManager _poolManager = null;
        [SerializeField] private float _spawnCooldown = 0.5f;
        [SerializeField] private float _spawnXRange = 5;
        [SerializeField] private float _spawnY = 6;
        [SerializeField] private float _spawnXVelocityRange = 2;
        [SerializeField] private Color[] _spawnColors = { };

        private float _spawnTimer = 0;
        #endregion

        #region Unity Events
        // NOTE: Make sure to only spawn in objects during Start or later,
        // unless you manipulate the script order to make sure
        // that ObjectPoolManager runs before your script.

        private void Update()
        {
            if (Mathf.Approximately(_spawnTimer, 0))
            {
                _spawnTimer = _spawnCooldown;
                // Spawn a Ball at the given position.
                Ball ball = _poolManager.Spawn<Ball>("Ball",
                    new Vector3(Random.Range(-_spawnXRange, _spawnXRange), _spawnY));
                // Initialize the ball with a random color and x velocity.
                // NOTE: The PoolObject was initialized upon Spawning.
                ball.Initialize(_spawnColors[Random.Range(0, _spawnColors.Length)],
                    Random.Range(-_spawnXVelocityRange, _spawnXVelocityRange));
            }
            else _spawnTimer = Mathf.Clamp(_spawnTimer - Time.deltaTime, 0, _spawnCooldown);
        }
        #endregion
    }
}