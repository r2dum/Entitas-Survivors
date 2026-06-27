using CodeBase.Runtime.Infrastructure.GameFlowStateMachine;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates.Registrar;
using CodeBase.Runtime.Infrastructure.StateMachine.Registrar;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Bootstraps
{
  public class GameBootstrapper : MonoBehaviour
  {
    private IStatesRegistrar _statesRegistrar;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(GameStatesRegistrar gameStatesRegistrar, GameStateMachine gameStateMachine)
    {
      _statesRegistrar = gameStatesRegistrar;
      _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
      _statesRegistrar.RegisterStates();
      _gameStateMachine.Enter<GameBootstrapState>();
    }
  }
}