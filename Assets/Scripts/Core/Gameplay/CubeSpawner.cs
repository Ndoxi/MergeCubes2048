using Core.Factories;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay
{
    public class CubeSpawner
    {
        private readonly CubeFactory _factory;
        private readonly List<Cube> _managedCubes;

        public CubeSpawner(CubeFactory factory)
        {
            _factory = factory;
            _managedCubes = new List<Cube>();
        }

        public Cube Spawn(Vector3 position, Quaternion rotation)
        {
            var cube = _factory.Create(GetRandomPower(), position, rotation);
            _managedCubes.Add(cube);

            return cube;
        }

        public void Destroy(Cube cube)
        {
            _managedCubes.Remove(cube);
            Object.Destroy(cube.gameObject);
        }

        public void DestroyAll()
        {
            foreach (var cube in _managedCubes)
            {
                if (cube != null)
                    Object.Destroy(cube.gameObject);
            }

            _managedCubes.Clear();
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