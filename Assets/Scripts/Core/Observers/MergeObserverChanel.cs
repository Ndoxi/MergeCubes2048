using Core.Data;
using System;

namespace Core.Observers
{
    public class MergeObserverChanel : IMergeObserver
    {
        public event Action<CubeData> OnNotify;

        public void Notify(CubeData data)
        {
            OnNotify?.Invoke(data);
        }
    }
}