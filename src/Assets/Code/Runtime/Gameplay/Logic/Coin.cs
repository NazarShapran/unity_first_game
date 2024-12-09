using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.infrastructure.SaveLoadRegistry;
using Code.Runtime.infrastructure.Service.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Coin : MonoBehaviour ,ICollectable
    {
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
            Destroy(gameObject);
        }
    }
}