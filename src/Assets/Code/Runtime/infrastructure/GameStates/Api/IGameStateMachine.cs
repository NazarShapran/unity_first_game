namespace Code.Runtime.infrastructure.GameStates.Api
{
    public interface IGameStateMachine
    {
        public void Enter<TState>() where TState : class, IEnterableState;
    }
}