using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Gameplay.View;
using Code.Runtime.infrastructure.Service.Random;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Aid : MonoBehaviour, ICollectable
    {
        [SerializeField] private MoveFadeDestroyer _moveFadeDestroyer;
        [SerializeField] private float _minHealthToHeal;
        [SerializeField] private float _maxHealthToHeal;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;
        
        private IRandomInterface _randomService;
        
        [Inject]
        private void Construct(IRandomInterface randomService)
        {
            _randomService = randomService;
        }
        public bool IsCollected { get; private set; }
        public void Collect(Collector collector)
        {
            IsCollected = true;
            var healthToHeal = _randomService.Range(_minHealthToHeal, _maxHealthToHeal);
            collector.GetComponent<Health>().Heal(healthToHeal);
            
            Destroy(_rigidbody2D);
            _collider2D.enabled = false;
            AudioManager.instance.Play("Aid");
            _moveFadeDestroyer.Destroy();
        }
    }
}