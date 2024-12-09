using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.SaveLoadRegistry;
using Code.Runtime.infrastructure.Service.Scene;
using Code.Runtime.infrastructure.Service.StaticData;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class BootstrapState : IEnterableState
    {
        private const string LevelSceneName = "level";
        private const string BootstrapSceneName = "BootstrapScene";
        
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IWalletService _walletService;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;

        public BootstrapState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService,
            IWalletService walletService, ISaveLoadRegistryService saveLoadRegistryService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadRegistryService = saveLoadRegistryService;
        }
        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName); 
            _staticDataService.LoadAll();
            
            _saveLoadRegistryService.RegisterAsProgressReader(_walletService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_walletService);
            
            _gameStateMachine.Enter<LoadProgressState>();
        }

    }
}