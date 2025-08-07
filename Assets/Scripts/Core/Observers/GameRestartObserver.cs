using Core.StateMachines;
using System;
using Zenject;

namespace Core.Observers
{
    public class GameRestartObserver : IObserver
    {
        public event Action OnNotify;

        private readonly LazyInject<IStateMachine> _stateMachineContainer;

        public GameRestartObserver(LazyInject<IStateMachine> stateMachineContainer)
        {
            _stateMachineContainer = stateMachineContainer;
        }

        public void Notify()
        {
            _stateMachineContainer.Value.Enter<GameplayState>();
            OnNotify?.Invoke();
        }
    }
}
