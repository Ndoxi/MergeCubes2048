using Core.Data;

namespace Core.Observers
{
    public interface ICollisionObserver
    {
        void Notify(CubeCollisionData data);
    }
}