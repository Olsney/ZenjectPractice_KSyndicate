using CodeBase.Services.StaticData;

namespace CodeBase.Infrastructure.States
{
  public class BootstrapState : IState
  {
    private const string Initial = "Initial";
    
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _staticDataService = staticDataService;
    }

    public void Enter()
    {
      _staticDataService.Load();
      _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
    }

    public void Exit()
    {
    }
    
    private void EnterLoadLevel() =>
      _stateMachine.Enter<LoadProgressState>();
  }
}