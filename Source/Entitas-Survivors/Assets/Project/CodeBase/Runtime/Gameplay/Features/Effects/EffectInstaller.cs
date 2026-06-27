using CodeBase.Runtime.Gameplay.Features.Effects.Factory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Effects
{
  public class EffectInstaller : Installer<EffectInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IEffectFactory>().To<EffectFactory>().AsSingle();
  }
}