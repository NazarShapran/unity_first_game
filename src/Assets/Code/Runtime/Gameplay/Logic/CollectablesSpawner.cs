using System.Collections;
using Code.Runtime.Extensions;
using Code.Runtime.infrastructure.Service.Random;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Runtime.Gameplay.Logic
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnInterval;
        
        [SerializeField]
        private GameObject _collectable;
        
        [SerializeField]
        private float _randomDetailX = 2;

        private IRandomInterface _random;

        public float RandomDetailX => _randomDetailX;

        [Inject]
        private void Construct(IRandomInterface random)
        {
            _random = random;
        }

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
            Instantiate(_collectable, transform.position.SetX(GetRandomX()), quaternion.identity, gameObject.transform);
        }

        private float GetRandomX()
        {
            return _random.Range(-_randomDetailX, _randomDetailX);
        }
    }
}