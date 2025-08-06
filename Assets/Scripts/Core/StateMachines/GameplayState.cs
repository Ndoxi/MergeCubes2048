using Core.Gameplay;
using Core.Processors;
using System;
using Zenject;

namespace Core.StateMachines
{
    public class GameplayState : IState
    {
        private readonly LazyInject<CubesLauncher> _cubesLauncherContainer;

        public GameplayState(LazyInject<CubesLauncher> cubesLauncherContainer)
        {
            _cubesLauncherContainer = cubesLauncherContainer;
        }

        public void OnEnter()
        {
            _cubesLauncherContainer.Value.gameObject.SetActive(true);
        }

        public void OnExit() { }
    }
}