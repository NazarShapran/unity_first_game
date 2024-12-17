using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Movements
{
    public class MoverX : MonoBehaviour
    {
        [SerializeField] 
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField] 
        private float _speed;
        
        public float Speed => _rigidbody2D.velocity.x;

        public bool isMoving => _rigidbody2D.velocity.x != 0;


        public void Move(float input)
        {
            _rigidbody2D.velocity = new Vector2(input * _speed, _rigidbody2D.velocity.y);
        }
    }
}