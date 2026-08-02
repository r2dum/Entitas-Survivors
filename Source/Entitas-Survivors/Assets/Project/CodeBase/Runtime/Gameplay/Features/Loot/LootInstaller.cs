using CodeBase.Runtime.Gameplay.Features.Loot.Factory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Loot
{
  public class LootInstaller : Installer<LootInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<ILootFactory>().To<LootFactory>().AsSingle();
  }
}