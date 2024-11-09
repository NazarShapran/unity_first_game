using UnityEngine;

namespace Code.Gameplay.Logic
{
    public class EnemiesSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnInterval;
        
        private float _timer;
        
        [SerializeField]
        private GameObject _enemy;

        private void Start()
        {
            _timer = _spawnInterval;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                SpawnEnemy();
                _timer = _spawnInterval;
            }
        }

        private void SpawnEnemy()
        {
            Instantiate(_enemy, gameObject.transform);
        }
    }
}