using Core.Data;
using Core.Gameplay;
using UnityEngine;
using Zenject;

namespace Core.Factories
{
    public class CubeFactory
    {
        private readonly Cube _prefab;
        private readonly IInstantiator _instantiator;

        public CubeFactory(Cube prefab, IInstantiator instantiator)
        {
            _prefab = prefab;
            _instantiator = instantiator;
        }

        public Cube Create(int power, Vector3 position, Quaternion rotation)
        {
            var cube = _instantiator.InstantiatePrefabForComponent<Cube>(_prefab, position, rotation, null);
            cube.Init(new CubeData(power));
            return cube;
        }
    }
}