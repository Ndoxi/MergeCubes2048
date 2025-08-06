using Core.Data;

namespace Core.Observers
{
    public interface IMergeObserver
    {
        void Notify(CubeData data);
    }
}