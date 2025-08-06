using Core.Data;
using System;

namespace Core.Observers
{
    public interface IMergeObserverChanel
    {
        void Notify(CubeData data);
        event Action<CubeData> OnMerge;
    }
}