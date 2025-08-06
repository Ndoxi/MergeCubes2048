using Core.Data;
using Core.Observers;
using UnityEngine;
using Zenject;

namespace Core.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubePhysicController : MonoBehaviour
    {
        public Cube cube => _cube;
        public CubeData cubeData => _cubeData;

        [SerializeField] private float _velocityThreshold;
        private Rigidbody _rigidbody;
        private Vector3 _cachedLinearVelocity;
        private Cube _cube;
        private CubeData _cubeData;
        private ICollisionObserver _observer;

        [Inject]
        private void Construct(ICollisionObserver observer)
        {
            _observer = observer;
        }

        public void Init(Cube cube, CubeData cubeData)
        {
            _cube = cube;
            _cubeData = cubeData;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _cachedLinearVelocity = _rigidbody.linearVelocity;
        }

        public void Hold()
        {
            _rigidbody.isKinematic = true;
        }

        public void Launch(Vector3 direction, float force)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(direction * force, ForceMode.Impulse);
        }

        public void MovePosition(Vector3 position)
        {
            _rigidbody.MovePosition(position);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_velocityThreshold > _cachedLinearVelocity.magnitude 
                || collision.rigidbody == null 
                || !collision.rigidbody.TryGetComponent(out CubePhysicController other))
            {
                return;
            }

            _observer.Notify(new CubeCollisionData(_cube, _cubeData, other.cube, other.cubeData, collision));
        }
    }
}