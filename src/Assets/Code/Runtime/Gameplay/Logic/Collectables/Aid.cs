using Code.Runtime.Gameplay.Logic.PlayerFeatures;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Gameplay.View;
using Code.Runtime.infrastructure.Service.Random;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class Aid : MonoBehaviour, ICollectable
    {
        [SerializeField] private MoveFadeDestroyer _moveFadeDestroyer;
        [SerializeField] private int _minHealthToHeal;
        [SerializeField] private int _maxHealthToHeal;
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