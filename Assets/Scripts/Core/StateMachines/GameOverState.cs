using Core.Data;
using Core.Observers;
using Core.Processors;
using Zenject;

namespace Core.StateMachines
{
    public class GameOverState : IState
    {
        private readonly LazyInject<IGameOverObserver> _gameOverObserverContainer;
        private readonly LazyInject<ScoreProcessor> _scoreProcessorContainer;
        private readonly LazyInject<TimeProcessor> _timeProcessorContainer;

        public GameOverState(LazyInject<IGameOverObserver> gameOverObserverContainer,
                             LazyInject<ScoreProcessor> scoreProcessorContainer,
                             LazyInject<TimeProcessor> timeProcessorContainer)
        {
            _gameOverObserverContainer = gameOverObserverContainer;
            _scoreProcessorContainer = scoreProcessorContainer;
            _timeProcessorContainer = timeProcessorContainer;
        }

        public void OnEnter() 
        {
            var data = new GameOverData(_scoreProcessorContainer.Value.score, 
                                        _timeProcessorContainer.Value.totalTime);

            _gameOverObserverContainer.Value.Notify(data);
        }

        public void OnExit() { }
    }
}