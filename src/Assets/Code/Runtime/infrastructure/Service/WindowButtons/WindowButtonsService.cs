using Code.Runtime.Data;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.GameStates.States;
using Code.Runtime.infrastructure.Service.Cleaning;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.Scene;
using Code.Runtime.infrastructure.Service.Windows;

namespace Code.Runtime.infrastructure.Service.WindowButtons
{
    public class WindowButtonsService : IWindowButtonsService
    {
        private ISceneLoader _sceneLoader;
        private ICleaningService _cleaningService;
        private IGameStateMachine _gameStateMachine;
        private IInputService _inputService;
        private IWindowService _windowService;

        public WindowButtonsService(ISceneLoader sceneLoader, ICleaningService cleaningService, IGameStateMachine gameStateMachine, IInputService inputService, IWindowService windowService)
        {
            _inputService = inputService;
            _windowService = windowService;
            
            _sceneLoader = sceneLoader;
            _cleaningService = cleaningService;
            _gameStateMachine = gameStateMachine;
        }

        public void PressPauseButton()
        {
            _windowService.OpenWindow(WindowTypeId.Pause);
            _inputService.Disable();
        }

        public void PressExitButton(string bootstrapSceneMenu)
        {
            _windowService.CloseWindow();
            _cleaningService.CleanLevel();
            _sceneLoader.LoadScene(bootstrapSceneMenu);
            _gameStateMachine.Enter<BootstrapState>();
        }

        public void PressRestartButton(string levelName)
        {
            _cleaningService.CleanLevel();
            _windowService.CloseWindow();
            _sceneLoader.LoadScene(levelName);
            _gameStateMachine.Enter<LoadLevelState, string>("Level");        
        }
        public void PressResumeButton()
        {
            _windowService.CloseWindow();
            _inputService.Enable();
        }
    }
}

