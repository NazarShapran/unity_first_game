using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.Gameplay.View.UI;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.infrastructure.Service.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;

        public GameFactory(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
            GameObject player = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.PlayerPrefab, position, Quaternion.identity, null); 
            player.GetComponent<Health>().CurrentHealth = _staticDataService.PlayerConfig.StartHealth;
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