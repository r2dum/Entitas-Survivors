using Zenject;

namespace CodeBase.Runtime.Common.EntityIndices
{
  public class EntityIndicesInstaller : Installer<EntityIndicesInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
  }
}