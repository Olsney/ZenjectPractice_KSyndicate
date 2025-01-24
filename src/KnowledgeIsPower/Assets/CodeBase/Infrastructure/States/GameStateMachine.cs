using CodeBase.Infrastructure.Factory;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly IStateFactory _factory;

        private IExitableState _activeState;

        public GameStateMachine(IStateFactory factory)
        {
            _factory = factory;
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _factory.GetState<TState>();
    }
}