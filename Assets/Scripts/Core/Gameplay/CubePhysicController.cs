using Core.Data;
using UnityEngine;

namespace Core.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class CubePhysicController : MonoBehaviour
    {
        public CubeData cubeData => _cubeData;

        [SerializeField] private float _velocityThreshold;
        private Rigidbody _rigidbody;
        private Vector3 _cachedLinearVelocity;
        private CubeData _cubeData;

        public void Init(CubeData cubeData)
        {
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
            _rigidbody.AddForce(direction * force);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_velocityThreshold > _cachedLinearVelocity.magnitude 
                || !collision.rigidbody.TryGetComponent(out CubePhysicController other))
            {
                return;
            }

            var collisionData = new CubeCollisionData(gameObject, _cubeData, other.gameObject, other.cubeData, collision);
        }
    }
}