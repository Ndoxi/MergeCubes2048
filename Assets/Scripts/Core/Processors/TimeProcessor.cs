using Core.Data;
using Core.Infrastructure;
using Core.Observers;
using System;
using UnityEngine;

namespace Core.Processors
{
    public class TimeProcessor : IDisposable
    {
        public event Action<int> OnUpdate;
        public float totalTime => _totalTime;

        private readonly ITickService _ticker;
        private readonly IMergeObserver _observerChanel;
        private float _totalTime;
        private float _time;
        private bool _paused;

        public TimeProcessor(ITickService ticker,
                             IMergeObserver observerChanel,
                             float initialTime,
                             bool paused)
        {
            _ticker = ticker;
            _observerChanel = observerChanel;
            _time = initialTime;
            _paused = paused;
        }

        public void Init()
        {
            _observerChanel.OnNotify += AddTimeOnMerge;
            _ticker.OnTick += Tick;
        }

        public void Dispose()
        {
            _observerChanel.OnNotify -= AddTimeOnMerge;
            _ticker.OnTick -= Tick;
        }

        public void SetPaused(bool paused)
        {
            _paused = paused;
        }

        private void Tick(float delta)
        {
            if (_paused)
                return;

            _totalTime += delta;
            _time -= delta;
            if (_time < 0f)
                _time = 0f;

            OnUpdate?.Invoke(Mathf.CeilToInt(_time));
        }

        private void AddTimeOnMerge(CubeData data)
        {
            _time += data.power + 2f;
            OnUpdate?.Invoke(Mathf.CeilToInt(_time));
        }
    }
}