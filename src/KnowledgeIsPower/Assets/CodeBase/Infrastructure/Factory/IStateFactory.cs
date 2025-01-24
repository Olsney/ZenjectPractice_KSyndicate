using CodeBase.Infrastructure.States;

namespace CodeBase.Infrastructure.Factory
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IExitableState;
    }
}