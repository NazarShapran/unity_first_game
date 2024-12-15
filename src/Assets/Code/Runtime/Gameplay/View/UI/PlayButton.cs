using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.GameStates.States;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        private IGameStateMachine _gameStateMachine;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            AudioManager.instance.Play("InterfaceButtons");
            _gameStateMachine.Enter<LoadLevelState, string>("Level");
        }
    }
}