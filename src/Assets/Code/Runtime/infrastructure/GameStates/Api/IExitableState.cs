namespace Code.Runtime.infrastructure.GameStates.Api
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}