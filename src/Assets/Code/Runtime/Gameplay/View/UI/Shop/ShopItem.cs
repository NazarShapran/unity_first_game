using System;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] 
        private Image _image;
        [SerializeField] 
        private TextMeshProUGUI _name;
        [SerializeField]
        private TextMeshProUGUI _price;
        [SerializeField]
        private Button _buyButton;
        
        private IShopService _shopService;
        private HatTypeId _hatType;
        
        public HatTypeId HatType => _hatType;

        public ShopItem(IShopService shopService)
        {
            _shopService = shopService;
        }
        public event Action Bought;

        [Inject]
        private void Construct(IShopService shopService)
        {
            _shopService = shopService;
        }

        private void Awake()
        {
            _buyButton.onClick.AddListener(Buy);
        }

        private void OnDestroy()
        {
            _buyButton.onClick.RemoveAllListeners();
        }


        public void UpdateView(Sprite sprite, string name, int price, HatTypeId hatType)
        {
            _image.sprite = sprite;
            _name.text = name;
            _price.text = price.ToString();
            _hatType = hatType;
        
            _buyButton.interactable = _shopService.CanBuyItem(_hatType);
        }
        private void Buy()
        {
            _shopService.BuyItem(_hatType);
            Bought?.Invoke();
        }
        
    }
}