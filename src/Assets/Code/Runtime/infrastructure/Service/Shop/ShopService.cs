using System;
using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.infrastructure.SaveLoad;
using Code.Runtime.infrastructure.Service.SaveLoad;
using Code.Runtime.infrastructure.Service.StaticData;
using Code.Runtime.StaticData;

namespace Code.Runtime.infrastructure.Service.Shop
{
    public class ShopService : IShopService
    {
        private List<HatTypeId> _ownedHats = new();
        private readonly IStaticDataService _staticDataService;
        private readonly IWalletService _walletService;
        private readonly ISaveLoadService _saveLoadService;

        public ShopService(IStaticDataService staticDataService, IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadService = saveLoadService;
        }
        public bool CanBuyItem(HatTypeId hatType)
        { 
           HatConfig hatConfig = _staticDataService.GetHatConfig(hatType);
           return _walletService.IsEnoughMoney(hatConfig.Price) && !_ownedHats.Contains(hatType);
        }

        public void BuyItem(HatTypeId hatType)
        {
            if (!CanBuyItem(hatType))
                throw new InvalidOperationException("Can't buy this item");
            
            _ownedHats.Add(hatType);
            _walletService.Purchase(_staticDataService.GetHatConfig(hatType).Price);
            _saveLoadService.SaveProgress();
        }

        public void Read(PlayerProgress playerProgress)
        {
            _ownedHats = playerProgress.OwnedHats;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.OwnedHats = _ownedHats;
        }
    }
}