namespace Code.Runtime.infrastructure.GameStates.Api
{
    public interface IStateProvider
    {
        TState GetState<TState>() where TState : class, IState;
    }
}