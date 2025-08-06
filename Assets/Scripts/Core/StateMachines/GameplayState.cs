using Core.Gameplay;
using Core.Processors;
using Zenject;

namespace Core.StateMachines
{
    public class GameplayState : IState
    {
        private readonly LazyInject<IStateMachine> _stateMachineContainer;
        private readonly LazyInject<CubesLauncher> _cubesLauncherContainer;
        private readonly LazyInject<TimeProcessor> _timeProcessorContainer;

        public GameplayState(LazyInject<IStateMachine> stateMachineContainer,
                             LazyInject<CubesLauncher> cubesLauncherContainer, 
                             LazyInject<TimeProcessor> timeProcessorContainer)
        {
            _stateMachineContainer = stateMachineContainer;
            _cubesLauncherContainer = cubesLauncherContainer;
            _timeProcessorContainer = timeProcessorContainer;
        }

        public void OnEnter()
        {
            _cubesLauncherContainer.Value.gameObject.SetActive(true);
            _timeProcessorContainer.Value.SetPaused(false);

            _timeProcessorContainer.Value.OnUpdate += UpdateState;
        }

        public void OnExit() 
        {
            _cubesLauncherContainer.Value.gameObject.SetActive(false);
            _timeProcessorContainer.Value.SetPaused(true);

            _timeProcessorContainer.Value.OnUpdate -= UpdateState;
        }

        private void UpdateState(int time)
        {
            if (time <= 0)
                _stateMachineContainer.Value.Enter<GameOverState>();
        }
    }
}