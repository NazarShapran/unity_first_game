using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;
using DG.Tweening;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class LevelState : IEnterableState, IExitableState
    {
        private IInputService _inputService;
        private readonly IStaticDataService _staticDataService;

        public LevelState(IInputService inputService, IStaticDataService staticDataService)
        {
            _inputService = inputService;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _inputService.Enable();
            AudioManager.instance.Stop("Menu");
            AudioManager.instance.Play("Level");
            Debug.Log($"Start level with health config: {_staticDataService.PlayerConfig.StartHealth}");
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}