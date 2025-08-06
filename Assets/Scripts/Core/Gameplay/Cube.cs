using Core.Data;
using UnityEngine;

namespace Core.Gameplay
{
    public class Cube : MonoBehaviour
    {
        [SerializeField] private CubePhysicController _controller;
        [SerializeField] private CubeView _view;
        private CubeData _cubeData;

        public void Init(CubeData cubeData)
        {
            _cubeData = cubeData;
            _controller.Init(this, cubeData);
            _view.Init(cubeData.value);
        }

        public void Hold()
        {
            _controller.Hold();
        }

        public void Launch(Vector3 direction, float force)
        {
            _controller.Launch(direction, force);
        }
    }
}