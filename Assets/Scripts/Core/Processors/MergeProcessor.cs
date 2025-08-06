using Core.Data;
using Core.Observers;
using System;
using UnityEngine;

namespace Core.Processors
{
    public class MergeProcessor : ICollisionObserver
    {
        private readonly float _impuseThreshold;
        private readonly float _mergeForce;
        private readonly IMergeObserverChanel _observerChanel;

        public MergeProcessor(float impuseThreshold,
                              float mergeForce,
                              IMergeObserverChanel observerChanel)
        {
            _impuseThreshold = impuseThreshold;
            _mergeForce = mergeForce;
            _observerChanel = observerChanel;
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

            UnityEngine.Object.Destroy(data.other.gameObject);
            
            data.parent.Init(new CubeData(data.parentData.power + 1));
            data.parent.Launch(Vector3.up, _mergeForce);

            _observerChanel.Notify(data.parentData);
        }
    }
}