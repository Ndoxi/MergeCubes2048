using Core.Mediators;
using Core.Observers;
using Zenject;

namespace Installers
{
    public class ObserversInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMergeObserver>()
                     .To<MergeObserverChanel>()
                     .AsSingle();            
            
            Container.Bind<IGameOverObserver>()
                     .To<GameOverObserver>()
                     .AsSingle();

            Container.Bind<IObserver>()
                     .To<GameRestartObserver>()
                     .AsSingle()
                     .WhenInjectedInto<GameOverMediator>();            
        }
    }
}