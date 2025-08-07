using Core.Gameplay;
using Core.Infrastructure;
using Core.Observers;
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
        private readonly LazyInject<TimeProcessor> _timeProcessorContainer;
        private readonly LazyInject<AudioPlayer> _audioPlayerContainer;
        private readonly LazyInject<IObserver> _observerContainer;

        public InitializationState(LazyInject<IStateMachine> stateMachineContainer, 
                                   LazyInject<CubesLauncher> cubesLauncherContainer, 
                                   LazyInject<ScoreProcessor> scoreProcessorContainer,
                                   LazyInject<TimeProcessor> timeProcessorContainer,
                                   LazyInject<AudioPlayer> audioPlayerContainer,
                                   LazyInject<IObserver> observerContainer)
        {
            _stateMachineContainer = stateMachineContainer;
            _cubesLauncherContainer = cubesLauncherContainer;
            _scoreProcessorContainer = scoreProcessorContainer;
            _timeProcessorContainer = timeProcessorContainer;
            _audioPlayerContainer = audioPlayerContainer;
            _observerContainer = observerContainer;
        }

        public void OnEnter()
        {
            _scoreProcessorContainer.Value.Init();
            _timeProcessorContainer.Value.Init();
            _audioPlayerContainer.Value.Init();
            _cubesLauncherContainer.Value.gameObject.SetActive(false);

            _stateMachineContainer.Value.Enter<GameplayState>();
        }

        public void OnExit() 
        {
            _observerContainer.Value.Notify();
        }
    }
}