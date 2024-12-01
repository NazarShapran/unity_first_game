using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Scene;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";
        private readonly ISceneLoader _sceneLoader;

        public MenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MenuSceneName);
        }
    }
}