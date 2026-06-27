using CodeBase.Runtime.Infrastructure.GameFlowStateMachine;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates.Registrar;
using CodeBase.Runtime.Infrastructure.StateMachine.Registrar;
using UnityEngine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Bootstraps
{
  public class MeadowBootstrapper : MonoBehaviour
  {
    private IStatesRegistrar _statesRegistrar;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(MeadowStatesRegistrar meadowStatesRegistrar, GameStateMachine gameStateMachine)
    {
      _statesRegistrar = meadowStatesRegistrar;
      _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
      _statesRegistrar.RegisterStates();
      _gameStateMachine.Enter<MeadowBootstrapState>();
    }
  }
}