using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.Service.WindowButtons;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class PauseButton : MonoBehaviour
    {
        private IWindowButtonsService _windowButtonsService;
        private AudioManager _audioManager;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService, AudioManager audioManager)
        {
            _windowButtonsService = windowButtonsService;
            _audioManager = audioManager;
        }

        public void Pause()
        {
            _audioManager.Play(SoundType.InterfaceButtons);
            _audioManager.Stop(SoundType.Level);
            _windowButtonsService.PressPauseButton();
        }
    }
}