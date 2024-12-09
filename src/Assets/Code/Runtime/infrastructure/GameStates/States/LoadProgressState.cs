using Code.Runtime.Data;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.SaveLoad;
using Code.Runtime.infrastructure.SaveLoadRegistry;
using Code.Runtime.infrastructure.Service.Progress;
using Code.Runtime.infrastructure.Service.SaveLoad;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class LoadProgressState : IEnterableState
    {
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;

        public LoadProgressState(IProgressService progressService, ISaveLoadService saveLoadService, IGameStateMachine gameStateMachine,
            ISaveLoadRegistryService saveLoadRegistryService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _gameStateMachine = gameStateMachine;
            _saveLoadRegistryService = saveLoadRegistryService;
        }
        public void Enter()
        {
            PlayerProgress playerProgress = _saveLoadService.LoadProgress() ?? new PlayerProgress();

            foreach (IReadProgress readProgress in _saveLoadRegistryService.ProgressReaders)
            {
                readProgress.Read(playerProgress);
            }
            _progressService.PlayerProgress = playerProgress;
            _gameStateMachine.Enter<MenuState>();
        }
    }
}