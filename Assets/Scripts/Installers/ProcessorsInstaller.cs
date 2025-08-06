using Core.Observers;
using Core.Processors;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProcessorsInstaller : MonoInstaller
    {
        [SerializeField] private float _impulseThreshold;
        [SerializeField] private float _mergeForce;

        public override void InstallBindings()
        {
            BindCollisionProcessor();
        }

        private void BindCollisionProcessor()
        {
            Container.Bind<ICollisionObserver>().To<MergeProcessor>().AsSingle().WithArguments(_impulseThreshold, _mergeForce);
        }
    }
}