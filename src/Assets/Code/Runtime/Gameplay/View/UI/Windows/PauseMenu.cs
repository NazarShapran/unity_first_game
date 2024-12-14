using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.Service.WindowButtons;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class PauseMenu : MonoBehaviour
    {
        private const string BootstrapSceneMenu = "BoostrapScene";
        private readonly string LevelName = "Level";
        
        [SerializeField]
        GameObject pauseMenu;

        private IWindowButtonsService _windowButtonsService;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService)
        {
            _windowButtonsService = windowButtonsService;
        }

        public void Resume()
        {
            AudioManager.instance.Play("Level");
            _windowButtonsService.PressResumeButton();
        }

        public void Restart()
        {
            AudioManager.instance.Play("Level");
            _windowButtonsService.PressRestartButton(LevelName);
        }

        public void ExitToMenu()
        {
            AudioManager.instance.Play("Menu");
            _windowButtonsService.PressExitButton(BootstrapSceneMenu);
        }
    }
}