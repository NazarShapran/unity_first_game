using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
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
        private AudioManager _audioManager;

        public LevelState(IInputService inputService, IStaticDataService staticDataService, AudioManager audioManager)
        {
            _inputService = inputService;
            _staticDataService = staticDataService;
            _audioManager = audioManager;
        }

        public void Enter()
        {
            _inputService.Enable();
            _audioManager.FadeOut(SoundType.Menu, 1.5f);
            _audioManager.FadeIn(SoundType.Level, 0.1f, 2f);
            Debug.Log($"Start level with health config: {_staticDataService.PlayerConfig.StartHealth}");
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}