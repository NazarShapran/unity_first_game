using Code.Runtime.Gameplay.Markers;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Factories;
using Code.Runtime.infrastructure.Service.Scene;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class LoadLevelState : IPayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(ISceneLoader sceneLoader,
            IGameStateMachine gameStateMachine,
            IGameFactory gameFactory)
        {
            _sceneLoader = sceneLoader;
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }
        public void Enter(string payload)
        {
            _sceneLoader.LoadScene(payload);
            GameObject spawnPlayer = SpawnPlayer();
            _gameFactory.CreateHud(spawnPlayer);
            _gameStateMachine.Enter<LevelState>();
        }

        public GameObject SpawnPlayer()
        {
            Vector3 playerSpawnPoint = Object.FindObjectOfType<PlayerSpawnPoint>().transform.position;
            return _gameFactory.CreatePlayer(playerSpawnPoint);
        }
    }
}