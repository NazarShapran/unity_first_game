using Code.Runtime.infrastructure.GameStates.Api;
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

        public BootstrapState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }
        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName); 
            _staticDataService.LoadAll();
            
            _gameStateMachine.Enter<MenuState>();
            //_gameStateMachine.Enter<LoadLevelState, string>("Level");
        }

    }
}