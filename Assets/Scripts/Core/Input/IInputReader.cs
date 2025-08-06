using System;

namespace Core.Input
{
    public interface IInputReader
    {
        event Action LaunchAction;
        event Action<float> MoveAction;
    }
}