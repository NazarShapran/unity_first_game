using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.Service.WindowButtons;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class PauseButton : MonoBehaviour
    {
        private IWindowButtonsService _windowButtonsService;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService)
        {
            _windowButtonsService = windowButtonsService;
        }

        public void Pause()
        {
            AudioManager.instance.Play("InterfaceButtons");
            AudioManager.instance.Stop("Level");
            _windowButtonsService.PressPauseButton();
        }
    }
}