using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.Gameplay.View;
using Code.Runtime.infrastructure.Service.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Coin : MonoBehaviour ,ICollectable
    {
        [SerializeField] 
        private MoveFadeDestroyer _moveFadeDestroyer;
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField]
        private Collider2D _collaider;
        
        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _walletService = walletService;
            _saveLoadService = saveLoadService;
        }
        public void Collect(Collector collector)
        { 
            _walletService.AddCoin();
            _saveLoadService.SaveProgress();
            IsCollected = true;

            Destroy(_rigidbody2D);
            _collaider.enabled = false;
            _moveFadeDestroyer.Destroy();
        }
    }
}