using Code.Runtime.Gameplay.Logic.Movements;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Jumps
{
    public class JumpHandler: MonoBehaviour
    {
        [SerializeField] private MoverY _mover;
        private int _currentJumpCount;
        [SerializeField] private int _maxJumpCount;
        [SerializeField] private float _jumpForce;

        public void ResetJumpCount() => _currentJumpCount = 0;

        public bool CanJump() => _currentJumpCount < _maxJumpCount;

        public void Jump()
        {
            if (!CanJump()) return;

            _mover.Jump(_jumpForce);
            _currentJumpCount++;
        }
        
        public void SetMaxJumpCount(int maxJumpCount) => _maxJumpCount = maxJumpCount;
    }
}