using Core.Data;
using Core.Gameplay;
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
        private readonly LazyInject<CubeSpawner> _cubeSpawnerContainer;
        private readonly LazyInject<CubesLauncher> _cubesLauncherContainer;

        public GameOverState(LazyInject<IGameOverObserver> gameOverObserverContainer,
                             LazyInject<ScoreProcessor> scoreProcessorContainer,
                             LazyInject<TimeProcessor> timeProcessorContainer,
                             LazyInject<CubeSpawner> cubeSpawnerContainer,
                             LazyInject<CubesLauncher> cubesLauncherContainer)
        {
            _gameOverObserverContainer = gameOverObserverContainer;
            _scoreProcessorContainer = scoreProcessorContainer;
            _timeProcessorContainer = timeProcessorContainer;
            _cubeSpawnerContainer = cubeSpawnerContainer;
            _cubesLauncherContainer = cubesLauncherContainer;
        }

        public void OnEnter() 
        {
            var data = new GameOverData(_scoreProcessorContainer.Value.score, 
                                        _timeProcessorContainer.Value.totalTime);

            _gameOverObserverContainer.Value.Notify(data);
        }

        public void OnExit() 
        {
            _cubeSpawnerContainer.Value.DestroyAll();
            _scoreProcessorContainer.Value.Reset();
            _timeProcessorContainer.Value.Reset();
            _cubesLauncherContainer.Value.Free();
        }
    }
}