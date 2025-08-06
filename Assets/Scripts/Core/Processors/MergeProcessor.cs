using Core.Data;
using Core.Factories;
using Core.Observers;
using UnityEngine;

namespace Core.Processors
{
    public class MergeProcessor : ICollisionObserver
    {
        private readonly CubeFactory _factory;
        private readonly float _impuseThreshold;
        private readonly float _mergeForce;

        public MergeProcessor(CubeFactory factory, float impuseThreshold, float mergeForce)
        {
            _factory = factory;
            _impuseThreshold = impuseThreshold;
            _mergeForce = mergeForce;
        }

        public void Notify(CubeCollisionData data)
        {
            Process(data);
        }

        private void Process(CubeCollisionData data)
        {
            if (data.collision.impulse.magnitude < _impuseThreshold 
                || data.parentData.power != data.otherData.power)
            {
                return;
            }

            var spawnPoint = data.collision.GetContact(0).point;
            spawnPoint.y += 0.2f;

            Object.Destroy(data.parent);
            Object.Destroy(data.other);

            var cube = _factory.Create(data.parentData.power + 1, spawnPoint, Quaternion.identity);
            cube.Launch(Vector3.up, _mergeForce);
        }
    }
}