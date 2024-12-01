using Code.Runtime.infrastructure.GameStates.Api;
using Zenject;

namespace Code.Runtime.infrastructure.GameStates.Provider
{
    public class StateProvider : IStateProvider
    {
        private readonly DiContainer _container;

        public StateProvider(DiContainer container)
        {
            _container = container;
        }
        
        public TState GetState<TState>() where TState : class, IState =>
            _container.Resolve<TState>();
    }
}