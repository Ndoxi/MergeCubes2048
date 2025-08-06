using Core.Gameplay;
using Zenject;

namespace Installers
{
    public class MainGameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSpawner();
        }

        private void BindSpawner()
        {
            Container.Bind<CubeSpawner>().To<CubeSpawner>().AsSingle();
        }
    }
}