using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;

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
            Debug.Log($"Start level with health config: {_staticDataService.PlayerConfig.StartHealth}");
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}