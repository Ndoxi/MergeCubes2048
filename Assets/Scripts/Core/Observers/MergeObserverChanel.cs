using Core.Data;
using System;

namespace Core.Observers
{
    public class MergeObserverChanel : IMergeObserverChanel
    {
        public event Action<CubeData> OnMerge;

        public void Notify(CubeData data)
        {
            OnMerge?.Invoke(data);
        }
    }
}