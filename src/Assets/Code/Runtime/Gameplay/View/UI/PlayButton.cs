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
        private readonly IGameStateMachine _stateMachine;

        [SerializeField]
        private Button _button;
        
        [Inject]
        public PlayButton(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
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
            _stateMachine.Enter<LoadLevelState, string>("level");
        }
    }
}