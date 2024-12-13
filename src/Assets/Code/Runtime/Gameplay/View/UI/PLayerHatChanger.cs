using System;
using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.PLayerInventory;
using Code.Runtime.infrastructure.Service.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class PLayerHatChanger : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private Image _harImage;

        private IPlayerInventoryService _invenrtoryService;
        private IStaticDataService _staticDataService;


        [Inject]
        private void Construct(IPlayerInventoryService playerInventoryService, IStaticDataService staticDataService)
        {
            _invenrtoryService = playerInventoryService;
            _staticDataService = staticDataService;
        }

        private void Awake()
        {
            _button.onClick.AddListener(ChangeHat);
        }
        private void Start()
        {
            UpdateView();
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ChangeHat);
        }

        private void ChangeHat()
        {
            if(!_invenrtoryService.HasAnyHat)
                return;
            _invenrtoryService.SelectNextHat();
            UpdateView();
        }

        private void UpdateView()
        {
            HatTypeId selectedHat = _invenrtoryService.SelectedHat;
            _harImage.enabled = selectedHat != HatTypeId.None;
            
            if (selectedHat == HatTypeId.None)
                return;
            
            HatConfig hatConfig = _staticDataService.GetHatConfig(selectedHat);
            _harImage.sprite = hatConfig.Sprite;
        }
    }
}