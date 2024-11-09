using Code.Gameplay.Logic;
using UnityEngine;

namespace Code.Gameplay.View
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        [SerializeField]
        private Animator _animator;
        
        [SerializeField]
        private MoverX _moverX;

        private void Update() => _animator.SetBool(IsRunning, _moverX.isMoving);
        
    }
}