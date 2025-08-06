using Core.Infrastructure;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class TickerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindTicker();
        }

        private void BindTicker()
        {
            Container.Bind<ITickService>().FromInstance(CreateTicker());
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