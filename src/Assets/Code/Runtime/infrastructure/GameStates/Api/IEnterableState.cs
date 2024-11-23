namespace Code.Runtime.infrastructure.GameStates.Api
{
    public interface IEnterableState : IState
    {
        void Enter();   
    }
}