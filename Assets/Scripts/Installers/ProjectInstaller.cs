using Core.Infrastructure;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindTicker();
            BindAudioPlayer();
        }

        private void BindTicker()
        {
            Container.Bind<ITickService>().FromInstance(CreateTicker());
        }

        private void BindAudioPlayer()
        {
            Container.Bind<AudioPlayer>().To<AudioPlayer>().AsSingle();
        }

        private Ticker CreateTicker()
        {
            var tickerGO = new GameObject
            {
                name = nameof(Ticker)
            };
            var ticker = tickerGO.AddComponent<Ticker>();
            DontDestroyOnLoad(ticker.gameObject);

            return ticker;
        }
    }
}