using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Jumps;
using Code.Runtime.Gameplay.Logic.PlayerFeatures;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Movements
{
    public class PlayerInputY : MonoBehaviour
    {
        [SerializeField] private MoverY _mover;

        [SerializeField] private LayerMask _groundLayerMask;
        
        [SerializeField] private GroundChecker _groundChecker;

        [SerializeField] private JumpHandler _jumpHandler;
        
        private IInputService _inputService;

        private SetMaxJumpsCount _setMaxJumpsCount;

        [Inject]
        private void Construct(IInputService inputService, IStaticDataService staticDataService)
        {
            _inputService = inputService;
            _setMaxJumpsCount = new SetMaxJumpsCount(staticDataService);
        }

        private void Update()
        {
            if (_inputService.GetJump())
            {
                if (_groundChecker.IsGrounded())
                {
                    _jumpHandler.ResetJumpCount();
                }

                if (_jumpHandler.CanJump())
                {
                    _jumpHandler.Jump();
                }
            }
        }

        public void SetJumpTypeId(JumpTypeId jumpTypeId)
        {
            _setMaxJumpsCount.SetJumpTypeId(jumpTypeId);
            _jumpHandler.SetMaxJumpCount(_setMaxJumpsCount.MaxJumpCount);
        }
    }
}