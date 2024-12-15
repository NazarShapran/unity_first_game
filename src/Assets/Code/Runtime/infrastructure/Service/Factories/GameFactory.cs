using Code.Runtime.Gameplay;
using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.Gameplay.View.UI;
using Code.Runtime.infrastructure.Service.PLayerInventory;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.infrastructure.Service.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;
        private readonly IPlayerInventoryService _playerInventoryService;

        public GameFactory(IStaticDataService staticDataService, IInstantiator instantiator, IPlayerInventoryService playerInventoryService)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
            _playerInventoryService = playerInventoryService;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
            GameObject player = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.PlayerPrefab, position, Quaternion.identity, null); 
            player.GetComponent<Health>().CurrentHealth = _staticDataService.PlayerConfig.StartHealth;
            player.GetComponentInChildren<Hat>().SetHat(_playerInventoryService.SelectedHat);
            player.GetComponent<PlayerInputY>().SetJumpTypeId(_playerInventoryService.GetMaxJump());
            
            return player;
        }

        public GameObject CreateHud(GameObject player)
        {
            Health health = player.GetComponent<Health>();
            Hud hud = _instantiator.InstantiatePrefabForComponent<Hud>(_staticDataService.HUDConfig.HudPrefab);
            hud.Setup(health);
            return hud.gameObject;
        }
    }
}