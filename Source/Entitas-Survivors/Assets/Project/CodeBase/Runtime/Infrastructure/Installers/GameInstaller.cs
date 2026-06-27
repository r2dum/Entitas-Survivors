using CodeBase.Runtime.Common.EntityIndices;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Infrastructure.Debug;
using CodeBase.Runtime.Infrastructure.EntityView;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates.Registrar;
using CodeBase.Runtime.Infrastructure.Identifiers;
using CodeBase.Runtime.Infrastructure.SceneLoading;
using CodeBase.Runtime.Infrastructure.StateMachine;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Installers
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      DebugInstaller.Install(Container);
      ContextsInstaller.Install(Container);
      IdentifierInstaller.Install(Container);
      AssetManagementInstaller.Install(Container);
      SceneLoaderInstaller.Install(Container);
      EntityIndicesInstaller.Install(Container);
      EntityViewInstaller.Install(Container);
      StateFactoryInstaller.Install(Container);
      GameStatesRegistrarInstaller.Install(Container);
      GameFlowStateMachineInstaller.Install(Container);
    }
  }
}