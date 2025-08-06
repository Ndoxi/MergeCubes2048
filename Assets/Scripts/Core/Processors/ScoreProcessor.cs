using Core.Data;
using Core.Observers;
using System;

namespace Core.Processors
{
    public class ScoreProcessor : IDisposable
    {
        public event Action<int> OnUpdate;

        private readonly IMergeObserverChanel _observerChanel;
        private int _score;

        public ScoreProcessor(IMergeObserverChanel observerChanel)
        {
            _observerChanel = observerChanel;
        }

        public void Init()
        {
            _observerChanel.OnMerge += UpdateScore;
        }

        public void Dispose()
        {
            _observerChanel.OnMerge -= UpdateScore;
        }

        private void UpdateScore(CubeData data)
        {
            _score += data.value / 2;
            OnUpdate?.Invoke(_score);
        }
    }
}