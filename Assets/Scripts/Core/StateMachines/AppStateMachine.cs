using System;
using System.Collections.Generic;
using Zenject;

namespace Core.StateMachines
{
    public class AppStateMachine : StateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        protected override Dictionary<Type, IState> states => _states;

        public AppStateMachine(IInstantiator instantiator)
        {
            _states = new Dictionary<Type, IState>()
            {
                { typeof(InitializationState), instantiator.Instantiate<InitializationState>() },
                { typeof(GameplayState), instantiator.Instantiate<GameplayState>() }
            };
        }
    }
}