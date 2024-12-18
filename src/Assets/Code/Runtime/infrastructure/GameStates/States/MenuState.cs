using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Scene;
using Zenject;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";
        private readonly ISceneLoader _sceneLoader;
        private IAudioManager _audioManager;
        [Inject]
        private void Construct(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        public MenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _audioManager.Play(SoundType.Menu);
            _sceneLoader.LoadScene(MenuSceneName);
        }
    }
}