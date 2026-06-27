using Zenject;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.GameStates.Registrar
{
  public class GameStatesRegistrarInstaller : Installer<GameStatesRegistrarInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<GameStatesRegistrar>().AsSingle();
  }
}