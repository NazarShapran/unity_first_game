using System.Collections;
using System.Collections.Generic;
using Code.Runtime.Extensions;
using Code.Runtime.infrastructure.Service.Random;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnInterval;
        
        [SerializeField]
        private List<GameObject> _collectables;
        
        [SerializeField]
        private float _randomDetailX = 2;

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
                SpawnEnemy(); 
            }
        }
        private void SpawnEnemy()
        {
            GameObject toSpawn = _random.ChooseFromList(_collectables);
            _instantiator.InstantiatePrefab(toSpawn, transform.position.SetX(GetRandomX()), quaternion.identity, gameObject.transform);
        }

        private float GetRandomX()
        {
            return _random.Range(-_randomDetailX, _randomDetailX);
        }
    }
}