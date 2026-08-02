using Zenject;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.LobbyStates.Registrar
{
  public class LobbyStatesRegistrarInstaller : Installer<LobbyStatesRegistrarInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<LobbyStatesRegistrar>().AsSingle();
  }
}