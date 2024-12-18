using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.Gameplay.View;
using Code.Runtime.infrastructure.Service.Random;
using Code.Runtime.infrastructure.Service.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class MinusMoney : MoveFadeDestroyer, ICollectable
    {
        [SerializeField] private MoveFadeDestroyer _moveFadeDestroyer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;
        
        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        private IRandomInterface _randomService;
        private IAudioManager _audioManager;
        
        [SerializeField] private int _minMinusCoins;
        [SerializeField] private int _maxMinusCoins;
        
        public bool IsCollected { get; private set; }
        
        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService, IRandomInterface randomService, IAudioManager audioManager)
        {
            _walletService = walletService;
            _saveLoadService = saveLoadService;
            _randomService = randomService;
            _audioManager = audioManager;
        }
        public void Collect(Collector collector)
        {
            var coinsToMinus = _randomService.Range(_minMinusCoins, _maxMinusCoins);
            
            _walletService.MinusCoins(coinsToMinus);
            _saveLoadService.SaveProgress();
            IsCollected = true;

            Destroy(_rigidbody2D);
            _collider2D.enabled = false;
            _audioManager.Play(SoundType.MinusMoney);
            _moveFadeDestroyer.Destroy();
        }
    }
}