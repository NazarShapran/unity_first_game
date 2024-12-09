using Code.Runtime.Gameplay.Markers;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Factories;
using Code.Runtime.infrastructure.Service.Scene;
using Code.Runtime.infrastructure.Service.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class LoadLevelState : IPayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;

        public LoadLevelState(ISceneLoader sceneLoader,
            IGameStateMachine gameStateMachine,
            IGameFactory gameFactory, IStaticDataService staticDataService)
        {
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
        }
        public void Enter(string payload)
        {
            _sceneLoader.LoadScene(payload);
            LevelData levelData = _staticDataService.GetLevelData(payload);
            
            GameObject spawnPlayer = _gameFactory.CreatePlayer(levelData.PlayerSpawnPoint);
            _gameFactory.CreateHud(spawnPlayer);
            
            _gameStateMachine.Enter<LevelState>();
        }
    }
}