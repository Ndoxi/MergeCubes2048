using Core.Observers;
using Core.StateMachines;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayBackgroundMusicObserverInstaller : MonoInstaller
    {
        [SerializeField] private AudioClip _defaultBackgroundMusicClip;
        [SerializeField] private float _volume = 1f;

        public override void InstallBindings()
        {
            Container.Bind<IObserver>()
                     .To<PlayBackgroundMusicObserver>()
                     .AsSingle()
                     .WithArguments(_defaultBackgroundMusicClip, _volume)
                     .WhenInjectedInto<InitializationState>();
        }
    }
}