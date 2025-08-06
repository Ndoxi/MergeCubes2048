namespace Core.StateMachines
{
    public interface IStateMachine
    {
        void Enter<T>() where T : IState; 
    }
}