using System;
using System.ComponentModel;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour
  {
    private IGameFactory _gameFactory;
    private LoadingCurtainProvider _loadingCurtainProvider;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(GameStateMachine gameStateMachine, IGameFactory gameFactory, LoadingCurtainProvider loadingCurtainProvider)
    {
      _gameStateMachine = gameStateMachine;
      _loadingCurtainProvider = loadingCurtainProvider;
      _gameFactory = gameFactory;
    
      DontDestroyOnLoad(this);
    }

    private void Start()
    {
      CreateCurtain();
      _gameStateMachine.Enter<BootstrapState>();
    }

    private void CreateCurtain()
    {
      GameObject curtain = _gameFactory.CreateCurtain();
      
      _loadingCurtainProvider.Instance = curtain.GetComponent<LoadingCurtain>();
    }
  }
}