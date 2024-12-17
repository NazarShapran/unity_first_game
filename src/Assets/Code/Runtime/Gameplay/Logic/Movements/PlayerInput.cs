using Code.Runtime.infrastructure.Service.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Movements
{
    public class PlayerInputX : MonoBehaviour
    {
        [SerializeField] 
        private MoverX _mover;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        void Update()
        {
            float movement = _inputService.GetMovement();
            _mover.Move(movement);
        }
    }
}
