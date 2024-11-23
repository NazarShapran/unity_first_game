using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.Service.Input;

namespace Code.Runtime.infrastructure.GameStates.States
{
    public class LevelState : IEnterableState, IExitableState
    {
        private IInputService _inputService;

        public LevelState(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.Enable();
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}