using Code.Runtime.infrastructure.Service.Random;
using Code.Runtime.infrastructure.Service.Scene;
using UnityEngine.SceneManagement;
using Zenject;

namespace Code.Runtime.infrastructure
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            Container.Bind<IRandomInterface>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<ISceneLoader>().LoadScene("level");
        }
    }
}