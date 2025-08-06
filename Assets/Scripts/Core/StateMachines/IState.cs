namespace Core.StateMachines
{
    public interface IState
    {
        void OnEnter();
        void OnExit();
    }
}