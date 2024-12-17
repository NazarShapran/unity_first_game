using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Movements
{
    public class MoverY : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rigidbody2D;

        public void Jump(float jumpForce = 1f)
        {
            if (_rigidbody2D != null)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
                _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogWarning("Rigidbody2D is not assigned.");
            }
        }
    }
}