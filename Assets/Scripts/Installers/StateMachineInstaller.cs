using Core.Gameplay;
using Core.StateMachines;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        [SerializeField] private CubesLauncher _cubesLauncher;

        public override void InstallBindings()
        {
            BindStateMachine();
        }

        private void BindStateMachine()
        {
            Container.Bind<IStateMachine>().To<AppStateMachine>().AsSingle();
            Container.Bind<CubesLauncher>().FromInstance(_cubesLauncher);
        }
    }
}