using Core.Observers;
using Core.Processors;
using System;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProcessorsInstaller : MonoInstaller
    {
        [Header("Time Processor Settings")]
        [SerializeField] private float _initialTime = 30f;
        [SerializeField] private bool _paused = true;

        [Header("Merge Processor Settings")]
        [SerializeField] private float _impulseThreshold = 0.2f;
        [SerializeField] private float _mergeForce = 3.5f;

        public override void InstallBindings()
        {
            Container.Bind(typeof(ScoreProcessor), typeof(IDisposable))
                     .To<ScoreProcessor>()
                     .AsSingle();            
            
            Container.Bind(typeof(TimeProcessor), typeof(IDisposable))
                     .To<TimeProcessor>()
                     .AsSingle()
                     .WithArguments(_initialTime, _paused);

            Container.Bind<ICollisionObserver>()
                     .To<MergeProcessor>()
                     .AsSingle()
                     .WithArguments(_impulseThreshold, _mergeForce);
        }
    }
}