using CodeBase.Runtime.Common;
using CodeBase.Runtime.Common.EntityIndices;
using CodeBase.Runtime.Infrastructure.AssetManagement;
using CodeBase.Runtime.Infrastructure.Debugs;
using CodeBase.Runtime.Infrastructure.EntityView;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates.Registrar;
using CodeBase.Runtime.Infrastructure.Identifiers;
using CodeBase.Runtime.Infrastructure.SceneLoading;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.Progress;
using CodeBase.Runtime.Services.StaticData;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Installers
{
  public class GameInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      DebugInstaller.Install(Container);
      CommonInstaller.Install(Container);
      ProgressInstaller.Install(Container);
      ContextsInstaller.Install(Container);
      IdentifierInstaller.Install(Container);
      SystemFactoryInstaller.Install(Container);
      AssetManagementInstaller.Install(Container);
      SceneLoaderInstaller.Install(Container);
      StaticDataInstaller.Install(Container);
      EntityIndicesInstaller.Install(Container);
      EntityViewInstaller.Install(Container);
      StateFactoryInstaller.Install(Container);
      GameStatesRegistrarInstaller.Install(Container);
      GameFlowStateMachineInstaller.Install(Container);
    }
  }
}