using Core.Input;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.Gameplay
{
    public class CubesLauncher : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _minPosX;
        [SerializeField] private float _maxPosX;
        [SerializeField] private float _launchForce;
        [SerializeField] private float _spawnDelay = 0.75f;
        private CubeSpawner _cubeSpawner;
        private IInputReader _inputReader;
        private Cube _current;

        [Inject]
        private void Construct(CubeSpawner cubeSpawner, IInputReader inputReader)
        {
            _cubeSpawner = cubeSpawner;
            _inputReader = inputReader;
        }

        private void OnEnable()
        {
            _inputReader.LaunchAction += LaunchCube;
            _inputReader.MoveAction += MoveCube;
        }

        private void OnDisable()
        {
            _inputReader.LaunchAction -= LaunchCube;
            _inputReader.MoveAction -= MoveCube;
        }

        public void Init()
        {
            PrepareCubeImmediately();
        }

        private void PrepareCubeImmediately()
        {
            if (_current != null)
                return;

            _current = _cubeSpawner.Spawn(_spawnPoint.position, Quaternion.identity);
            _current.Hold();
        }

        private IEnumerator PrepareCube()
        {
            yield return new WaitForSeconds(_spawnDelay);
            PrepareCubeImmediately();
        }

        private void LaunchCube()
        {
            if (_current == null)
                return;

            _current.Launch(Vector3.forward, _launchForce);
            _current = null;

            StartCoroutine(PrepareCube());
        }

        private void MoveCube(float value)
        {
            if (_current == null)
                return;

            var newPos = _current.transform.position;
            newPos.x = Mathf.Clamp(newPos.x + value * Time.deltaTime, _minPosX, _maxPosX);
            _current.transform.position = newPos;
        }
    }
}