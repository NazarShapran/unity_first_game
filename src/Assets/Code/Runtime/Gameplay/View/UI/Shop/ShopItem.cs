using System;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
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
        
        private AudioManager _audioManager;
        private IShopService _shopService;
        private ShopItemId _shopTypeId;
        
        public ShopItemId ShopTypeId => _shopTypeId;
        
        [Inject]
        private void Construct(AudioManager audioManager)
        {
            _audioManager = audioManager;
        }
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


        public void UpdateView(Sprite sprite, string name, int price, ShopItemId hatType)
        {
            _image.sprite = sprite;
            _name.text = name;
            _price.text = price.ToString();
            _shopTypeId = hatType;
        
            _buyButton.interactable = _shopService.CanBuyItem(_shopTypeId);
        }
        private void Buy()
        {
            _shopService.BuyItem(_shopTypeId);
            _audioManager.Play(SoundType.BuyItem);
            Bought?.Invoke();
        }
        
    }
}