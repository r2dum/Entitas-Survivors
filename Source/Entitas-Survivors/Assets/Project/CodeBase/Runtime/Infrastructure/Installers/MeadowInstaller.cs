using CodeBase.Runtime.Gameplay.Core;
using CodeBase.Runtime.Gameplay.Features.Abilities;
using CodeBase.Runtime.Gameplay.Features.Armaments;
using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Enchants;
using CodeBase.Runtime.Gameplay.Features.Enemies;
using CodeBase.Runtime.Gameplay.Features.Hero;
using CodeBase.Runtime.Gameplay.Features.LevelUp;
using CodeBase.Runtime.Gameplay.Features.Loot;
using CodeBase.Runtime.Gameplay.Features.Statuses;
using CodeBase.Runtime.Gameplay.GameplayStaticData;
using CodeBase.Runtime.Gameplay.Levels;
using CodeBase.Runtime.Infrastructure.EntityView;
using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.MeadowStates.Registrar;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.UI.Windows;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Installers
{
  public class MeadowInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      CoreGameplayInstaller.Install(Container);
      GameplayStaticDataInstaller.Install(Container);
      LevelInstaller.Install(Container);
      EntityViewInstaller.Install(Container);
      HeroInstaller.Install(Container);
      EnemyInstaller.Install(Container);
      ArmamentInstaller.Install(Container);
      AbilityInstaller.Install(Container);
      EnchantInstaller.Install(Container);
      EffectInstaller.Install(Container);
      StatusesInstaller.Install(Container);
      LootInstaller.Install(Container);
      LevelUpInstaller.Install(Container);
      WindowsInstaller.Install(Container);
      SystemFactoryInstaller.Install(Container);
      StateFactoryInstaller.Install(Container);
      MeadowStatesRegistrarInstaller.Install(Container);
    }
  }
}