namespace Code.Runtime.infrastructure.Service.Input
{
    public class InputService : IInputService
    {
        private const string AxisHorizontal = "Horizontal";
        private const string JumpButtonName = "Jump";

        private bool _enabled;
        public void Enable() => _enabled = true;
        public void Disable() => _enabled = false;
        
        public float GetMovement() =>
            _enabled 
                ? UnityEngine.Input.GetAxis(AxisHorizontal)
                : 0;

        public bool GetJump()
        {
            return _enabled && UnityEngine.Input.GetButtonDown(JumpButtonName);
        }
    }
}