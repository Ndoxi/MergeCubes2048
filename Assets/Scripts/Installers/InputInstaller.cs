using Core.Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private TouchInputReader _inputReader;

        public override void InstallBindings()
        {
            BindInputReader();
        }

        private void BindInputReader()
        {
            Container.Bind<IInputReader>()
                     .To<TouchInputReader>()
                     .FromComponentInNewPrefab(_inputReader)
                     .AsSingle();
        }
    }
}