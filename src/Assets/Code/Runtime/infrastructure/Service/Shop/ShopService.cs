using System;
using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.Gameplay.View.UI.Shop;
using Code.Runtime.infrastructure.SaveLoad;
using Code.Runtime.infrastructure.Service.PLayerInventory;
using Code.Runtime.infrastructure.Service.SaveLoad;
using Code.Runtime.infrastructure.Service.StaticData;
using Code.Runtime.StaticData;

namespace Code.Runtime.infrastructure.Service.Shop
{
    public class ShopService : IShopService
    {
        private List<ShopItemId> _purchasedItems = new();
        private readonly IStaticDataService _staticDataService;
        private readonly IWalletService _walletService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPlayerInventoryService _playerInventoryService;

        public ShopService(IStaticDataService staticDataService, IWalletService walletService, ISaveLoadService saveLoadService,
            IPlayerInventoryService playerInventoryService)
        {
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadService = saveLoadService;
            _playerInventoryService = playerInventoryService;
        }
        public bool CanBuyItem(ShopItemId hatType)
        { 
           ShopItemConfig shopItemConfig = _staticDataService.GetShopItemConfig(hatType);
           return _walletService.IsEnoughMoney(shopItemConfig.Price) && !_purchasedItems.Contains(hatType);
        }

        public void BuyItem(ShopItemId hatType)
        {
            if (!CanBuyItem(hatType))
                throw new InvalidOperationException("Can't buy this item");
            
            ShopItemConfig config = _staticDataService.GetShopItemConfig(hatType);
            _purchasedItems.Add(hatType);
            _walletService.Purchase(config.Price);

            if (config.HatTypeId != HatTypeId.None)
            {
                _playerInventoryService.AddHat(config.HatTypeId);
            }

            _saveLoadService.SaveProgress();
        }

        public void Read(PlayerProgress playerProgress)
        {
            _purchasedItems = playerProgress.PurchesedItems;
        }

        public void Write(PlayerProgress playerProgress)
        {
            playerProgress.PurchesedItems = _purchasedItems;
        }
    }
}