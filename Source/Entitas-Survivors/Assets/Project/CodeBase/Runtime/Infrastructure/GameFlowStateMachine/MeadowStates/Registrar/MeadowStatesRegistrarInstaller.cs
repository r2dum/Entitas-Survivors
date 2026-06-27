using Zenject;

namespace CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates.Registrar
{
  public class MeadowStatesRegistrarInstaller : Installer<MeadowStatesRegistrarInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<MeadowStatesRegistrar>().AsSingle();
  }
}