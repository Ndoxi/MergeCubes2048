using Core.Data;
using System;

namespace Core.Observers
{
    public class GameOverObserver : IGameOverObserver
    {
        public event Action<GameOverData> OnNotify;

        public void Notify(GameOverData data)
        {
            OnNotify?.Invoke(data);
        }
    }
}
