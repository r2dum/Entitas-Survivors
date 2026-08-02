using CodeBase.Runtime.Infrastructure.GameFlowStateMachine;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.LobbyStates;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.LobbyStates.Registrar;
using CodeBase.Runtime.Infrastructure.StateMachine.Registrar;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Bootstraps
{
  public class LobbyBootstrapper : MonoBehaviour
  {
    private IStatesRegistrar _statesRegistrar;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(LobbyStatesRegistrar lobbyStatesRegistrar, GameStateMachine gameStateMachine)
    {
      _statesRegistrar = lobbyStatesRegistrar;
      _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
      _statesRegistrar.RegisterStates();
      _gameStateMachine.Enter<LobbyFeatureState>();
    }
  }
}