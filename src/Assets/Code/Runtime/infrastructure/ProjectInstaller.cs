using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.GameStates.Provider;
using Code.Runtime.infrastructure.GameStates.StateMachine;
using Code.Runtime.infrastructure.GameStates.States;
using Code.Runtime.infrastructure.Service.Factories;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.Random;
using Code.Runtime.infrastructure.Service.Scene;
using Code.Runtime.infrastructure.Service.StaticData;
using Zenject;

namespace Code.Runtime.infrastructure
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindGameStates();
            BindGameFactories();
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelState>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IRandomInterface>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    }
}