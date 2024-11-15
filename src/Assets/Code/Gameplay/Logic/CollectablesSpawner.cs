using System.Collections;
using UnityEngine;

namespace Code.Gameplay.Logic
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnInterval;
        
        [SerializeField]
        private GameObject _enemy;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                SpawnEnemy(); 
            }
        }
        private void SpawnEnemy()
        {
            Instantiate(_enemy, gameObject.transform);
        }
    }
}