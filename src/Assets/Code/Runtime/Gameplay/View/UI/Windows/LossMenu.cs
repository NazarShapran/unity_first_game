using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.Service.WindowButtons;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class LossMenu : MonoBehaviour
    {
        private const string BootstrapSceneMenu = "BootstrapScene";
        private readonly string LevelName = "Level";
        
        [SerializeField]
        GameObject lossMenu;

        private IWindowButtonsService _windowButtonsService;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService)
        {
            _windowButtonsService = windowButtonsService;
        }
        
        public void Restart()
        {
            AudioManager.instance.Play("InterfaceButtons");
            _windowButtonsService.PressRestartButton(BootstrapSceneMenu);
        }
        
        public void ExitToMenu()
        {
            AudioManager.instance.Play("InterfaceButtons");
            AudioManager.instance.Play("Menu");
            _windowButtonsService.PressExitButton(LevelName);
        }
    }
}