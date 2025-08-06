using Core.Data;
using Core.Observers;
using System;

namespace Core.Processors
{
    public class ScoreProcessor : IDisposable
    {
        public event Action<int> OnUpdate;
        public int score => _score;

        private readonly IMergeObserver _observerChanel;
        private int _score;

        public ScoreProcessor(IMergeObserver observerChanel)
        {
            _observerChanel = observerChanel;
        }

        public void Init()
        {
            _observerChanel.OnNotify += UpdateScore;
        }

        public void Dispose()
        {
            _observerChanel.OnNotify -= UpdateScore;
        }

        private void UpdateScore(CubeData data)
        {
            _score += data.value / 2;
            OnUpdate?.Invoke(_score);
        }
    }
}