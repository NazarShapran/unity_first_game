using System.Collections.Generic;
using Code.Runtime.infrastructure.Service.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Shop
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopItem _shopItemPrefab;

        [SerializeField] private Transform _contentContainer;

        private IStaticDataService _staticDataService;
        private IInstantiator _instantiator;
        private readonly List<ShopItem> _shopItems = new();

        [Inject]
        private void Construct(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        private void Start()
        {
            IEnumerable<ShopItemConfig> hatsConfigs = _staticDataService.GetHatsConfigs();

            foreach (ShopItemConfig hatConfig in hatsConfigs)
            {
                ShopItem shopItem =
                    _instantiator.InstantiatePrefabForComponent<ShopItem>(_shopItemPrefab, _contentContainer);
                _shopItems.Add(shopItem);
                shopItem.Bought += OnItemBought;
                shopItem.UpdateView(hatConfig.Sprite, hatConfig.Name, hatConfig.Price, hatConfig.ShopItemId);
            }
        }

        private void UpdateShopItemsView()
        {
            foreach (ShopItem shopItem in _shopItems)
            {
                ShopItemConfig shopItemConfig = _staticDataService.GetShopItemConfig(shopItem.ShopTypeId);
                shopItem.UpdateView(shopItemConfig.Sprite, shopItemConfig.Name, shopItemConfig.Price, shopItemConfig.ShopItemId);
            }
        }   

        private void OnItemBought()
        {
            UpdateShopItemsView();
        }
    }
}