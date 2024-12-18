using System.Collections;
using System.Linq;
using Code.Runtime.Extensions;
using UnityEngine;
using Zenject;
using Code.Runtime.infrastructure.Service.Random;
using Code.Runtime.StaticData;
using Unity.Mathematics;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval;
        [SerializeField] private CollectablesSpawnConfig _config; // Підключаємо конфіг

        [SerializeField] private int _randomDetailX = 2;

        private IRandomInterface _random;
        private IInstantiator _instantiator;

        public float RandomDetailX => _randomDetailX;

        [Inject]
        private void Construct(IRandomInterface random, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _random = random;
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                SpawnCollectable(); 
            }
        }

        private void SpawnCollectable()
        {
            if (_config == null || _config.Collectables == null || _config.Collectables.Count == 0)
            {
                Debug.LogWarning("No collectables configured for spawning.");
                return;
            }

            GameObject toSpawn = GetRandomCollectable();
            _instantiator.InstantiatePrefab(toSpawn, transform.position.SetX(GetRandomX()),quaternion.identity, gameObject.transform);
        }


        private GameObject GetRandomCollectable()
        {
            int totalWeight = _config.Collectables.Sum(item => item.Weight);
            int randomPoint = _random.Range(0, totalWeight);
            int currentWeight = 0;

            foreach (var collectable in _config.Collectables)
            {
                currentWeight += collectable.Weight;
                if (randomPoint <= currentWeight)
                    return collectable.CollectablePrefab;
            }

            return _config.Collectables[0].CollectablePrefab;
        }
        private float GetRandomX() => _random.Range(-_randomDetailX, _randomDetailX);
    }
}
