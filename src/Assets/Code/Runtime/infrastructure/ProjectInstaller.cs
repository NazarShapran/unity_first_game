using Code.Runtime.Gameplay.Services.Wallet;
using Code.Runtime.infrastructure.GameStates.Api;
using Code.Runtime.infrastructure.GameStates.Provider;
using Code.Runtime.infrastructure.GameStates.StateMachine;
using Code.Runtime.infrastructure.GameStates.States;
using Code.Runtime.infrastructure.SaveLoadRegistry;
using Code.Runtime.infrastructure.Service.Factories;
using Code.Runtime.infrastructure.Service.Input;
using Code.Runtime.infrastructure.Service.PLayerInventory;
using Code.Runtime.infrastructure.Service.Progress;
using Code.Runtime.infrastructure.Service.Random;
using Code.Runtime.infrastructure.Service.SaveLoad;
using Code.Runtime.infrastructure.Service.Scene;
using Code.Runtime.infrastructure.Service.Shop;
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
            BindGameplayServices();
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IWalletService>().To<WalletService>().AsSingle();
            Container.Bind<IShopService>().To<ShopService>().AsSingle();
            Container.Bind<IPlayerInventoryService>().To<PlayerInventoryService>().AsSingle();
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
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
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
            Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<ISaveLoadRegistryService>().To<SaveLoadRegistryService>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    }
}