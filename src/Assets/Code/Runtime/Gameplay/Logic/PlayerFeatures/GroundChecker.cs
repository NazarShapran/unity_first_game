using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.PlayerFeatures
{
    public class GroundChecker: MonoBehaviour
    {
        [SerializeField] private Transform _foot;
        [SerializeField] private LayerMask _groundLayerMask;
        private readonly float _raycastDistance = 0.1f;

        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(_foot.position, Vector2.down, _raycastDistance, _groundLayerMask);
            return hit.collider != null;
        }
    }
}