using Core.Data;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class MainDataInstaller : MonoInstaller
    {
        [SerializeField] private CubeColorsData _cubeColorsData;

        public override void InstallBindings()
        {
            BindCubesColorData();
        }

        private void BindCubesColorData()
        {
            Container.Bind<CubeColorsData>().FromInstance(_cubeColorsData);
        }
    }
}