using Core.Gameplay;
using System;
using Zenject;

namespace Core.StateMachines
{
    public class InitializationState : IState
    {
        private readonly LazyInject<IStateMachine> _stateMachineContainer;
        private readonly LazyInject<CubesLauncher> _cubesLauncher;

        public InitializationState(LazyInject<IStateMachine> stateMachineContainer, 
                                   LazyInject<CubesLauncher> cubesLauncher)
        {
            _stateMachineContainer = stateMachineContainer;
            _cubesLauncher = cubesLauncher;
        }

        public void OnEnter()
        {
            _stateMachineContainer.Value.Enter<GameplayState>();
        }

        public void OnExit() 
        {
            _cubesLauncher.Value.Init();
        }
    }
}