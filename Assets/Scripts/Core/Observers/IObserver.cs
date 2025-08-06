using System;

namespace Core.Observers
{
    public interface IObserver<T>
    {
        event Action<T> OnNotify;
        void Notify(T data);
    }
}