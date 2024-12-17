using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Scene;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";
        private readonly ISceneLoader _sceneLoader;
        private AudioManager _audioManager;

        public MenuState(ISceneLoader sceneLoader, AudioManager audioManager)
        {
            _sceneLoader = sceneLoader;
            _audioManager = audioManager;
        }

        public void Enter()
        {
            _audioManager.Play(SoundType.Menu);
            _sceneLoader.LoadScene(MenuSceneName);
        }
    }
}