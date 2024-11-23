using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Scene;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class BootstrapState : IEnterableState
    {
        private const string LevelSceneName = "level";
        private const string BootstrapSceneName = "BootstrapScene";
        
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName); 
            _sceneLoader.LoadScene(LevelSceneName);
            _gameStateMachine.Enter<LevelState>();
        }

    }
}