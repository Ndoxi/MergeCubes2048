using System;

namespace Core.Infrastructure
{
    public interface ITickService
    {
        event Action<float> OnTick;
    }
}