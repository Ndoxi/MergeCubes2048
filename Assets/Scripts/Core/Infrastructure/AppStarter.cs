using Core.StateMachines;
using UnityEngine;
using Zenject;

namespace Core.Infrastructure
{
    public class AppStarter : MonoBehaviour
    {
        private IStateMachine _stateMachine;

        [Inject]
        private void Construct(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            _stateMachine.Enter<InitializationState>();
        }
    }
}