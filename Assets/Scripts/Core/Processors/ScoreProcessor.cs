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
        private bool _initialized;

        public ScoreProcessor(IMergeObserver observerChanel)
        {
            _observerChanel = observerChanel;
        }

        public void Init()
        {
            if (_initialized)
                return;

            _observerChanel.OnNotify += UpdateScore;

            _initialized = true;
        }

        public void Dispose()
        {
            _observerChanel.OnNotify -= UpdateScore;
        }

        public void Reset()
        {
            _score = 0;
            OnUpdate?.Invoke(_score);
        }

        private void UpdateScore(CubeData data)
        {
            _score += data.value / 2;
            OnUpdate?.Invoke(_score);
        }
    }
}