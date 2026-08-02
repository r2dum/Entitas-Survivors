using CodeBase.Runtime.Gameplay.Features.Enchants.UIFactory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Enchants
{
  public class EnchantInstaller : Installer<EnchantInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IEnchantUIFactory>().To<EnchantUIFactory>().AsSingle();
  }
}