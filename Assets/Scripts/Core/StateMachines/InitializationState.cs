using Core.Gameplay;
using Core.Processors;
using System;
using Zenject;

namespace Core.StateMachines
{
    public class InitializationState : IState
    {
        private readonly LazyInject<IStateMachine> _stateMachineContainer;
        private readonly LazyInject<CubesLauncher> _cubesLauncherContainer;
        private readonly LazyInject<ScoreProcessor> _scoreProcessorContainer;

        public InitializationState(LazyInject<IStateMachine> stateMachineContainer, 
                                   LazyInject<CubesLauncher> cubesLauncherContainer, 
                                   LazyInject<ScoreProcessor> scoreProcessorContainer)
        {
            _stateMachineContainer = stateMachineContainer;
            _cubesLauncherContainer = cubesLauncherContainer;
            _scoreProcessorContainer = scoreProcessorContainer;
        }

        public void OnEnter()
        {
            _scoreProcessorContainer.Value.Init();
            _cubesLauncherContainer.Value.Init();
            _cubesLauncherContainer.Value.gameObject.SetActive(false);

            _stateMachineContainer.Value.Enter<GameplayState>();
        }

        public void OnExit() { }
    }
}