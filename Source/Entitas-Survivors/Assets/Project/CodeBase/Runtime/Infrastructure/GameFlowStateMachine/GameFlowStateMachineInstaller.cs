using Zenject;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine
{
  public class GameFlowStateMachineInstaller : Installer<GameFlowStateMachineInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
  }
}