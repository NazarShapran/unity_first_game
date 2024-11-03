using UnityEngine;

namespace Code
{
    public class PlayerInputX : MonoBehaviour
    {
        private const string AxisHorizontat = "Horizontal";
        [SerializeField] 
        private MoverX _mover;

        void Update()
        {
            float input = Input.GetAxis(AxisHorizontat);
            _mover.Move(input);
        }
    }
}
