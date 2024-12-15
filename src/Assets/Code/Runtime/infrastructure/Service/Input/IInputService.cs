namespace Code.Runtime.infrastructure.Service.Input
{
    public interface IInputService
    {
        void Enable();
        void Disable();
        float GetMovement();
        bool GetJump();
    }
}