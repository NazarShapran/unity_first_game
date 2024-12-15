using Code.Runtime.Data;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerInputY : MonoBehaviour
    {
        [SerializeField]
        private MoverY _mover;

        [SerializeField]
        private JumpTypeId _jumpTypeId = JumpTypeId.None;

        [SerializeField]
        private LayerMask _groundLayerMask;
        
        private IInputService _inputService;
        
        [SerializeField]
        private GroundChecker _groundChecker;
        
        [SerializeField]
        private JumpHandler _jumpHandler;
        
        private JumpTypeManager _jumpTypeManager;

        [Inject]
        private void Construct(IInputService inputService, IStaticDataService staticDataService)
        {
            _inputService = inputService;
            _jumpTypeManager = new JumpTypeManager(staticDataService);
            Debug.Log("Player Input Initialized");
        }

        private void Update()
        {
            if (_inputService.GetJump())
            {
                if (_groundChecker.IsGrounded())
                {
                    _jumpHandler.ResetJumpCount();
                }
                
                Debug.LogWarning($"Jump Type: {_jumpTypeId}");

                if (_jumpHandler.CanJump())
                {
                    _jumpHandler.Jump();
                }
            }
        }

        public void SetJumpTypeId(JumpTypeId jumpTypeId)
        {
            _jumpTypeManager.SetJumpTypeId(jumpTypeId);
            _jumpHandler.SetMaxJumpCount(_jumpTypeManager.MaxJumpCount);
        }
    }
}