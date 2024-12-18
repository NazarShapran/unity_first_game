using Code.Runtime.Data;
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
        private IAudioManager _audioManager;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService, IAudioManager audioManager)
        {
            _windowButtonsService = windowButtonsService;
            _audioManager = audioManager;
        }
        
        public void Restart()
        {
            _audioManager.Play(SoundType.InterfaceButtons);
            _windowButtonsService.PressRestartButton(BootstrapSceneMenu);
        }
        
        public void ExitToMenu()
        {
            _audioManager.Play(SoundType.InterfaceButtons);
            _audioManager.Play(SoundType.Menu);
            _windowButtonsService.PressExitButton(LevelName);
        }
    }
}