using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.StateMachines
{
    public abstract class StateMachine : IStateMachine
    {
        protected abstract Dictionary<Type, IState> states { get; }
        private IState _current;

        public void Enter<T>() where T : IState
        {
            if (_current != null)
                _current.OnExit();

            _current = GetState<T>();
            _current.OnEnter();
        }

        private IState GetState<T>() where T : IState
        {
            return states[typeof(T)];
        } 
    }
}