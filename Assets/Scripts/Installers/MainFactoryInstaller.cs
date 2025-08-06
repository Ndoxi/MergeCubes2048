using Core.Factories;
using Core.Gameplay;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainFactoryInstaller : MonoInstaller
    {
        [SerializeField] private Cube _prefab;

        public override void InstallBindings()
        {
            BindFactory();
        }

        private void BindFactory()
        {
            Container.Bind<CubeFactory>().To<CubeFactory>().AsSingle().WithArguments(_prefab);
        }
    }
}