using Core.Factories;
using UnityEngine;

namespace Core.Gameplay
{
    public class CubeSpawner
    {
        private readonly CubeFactory _factory;

        public CubeSpawner(CubeFactory factory)
        {
            _factory = factory;
        }

        public Cube Spawn(Vector3 position, Quaternion rotation)
        {
            var cube = _factory.Create(GetRandomPower(), position, rotation);
            return cube;
        }

        private int GetRandomPower()
        {
            //75% - 1, 25% - 2
            float rand = Random.value;
            if (rand < 0.75f)
                return 1;
            else
                return 2;
        }
    }
}