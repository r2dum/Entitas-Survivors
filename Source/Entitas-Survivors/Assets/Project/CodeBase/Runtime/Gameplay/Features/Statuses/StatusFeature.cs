using CodeBase.Runtime.Gameplay.Features.Statuses.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Statuses
{
  public sealed class StatusFeature : Feature
  {
    public StatusFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<StatusDurationSystem>());
      Add(systemFactory.Create<PeriodicPoisonDamageStatusSystem>());
      Add(systemFactory.Create<ApplySpeedModifierStatusSystem>());
      Add(systemFactory.Create<ApplyHealStatusSystem>());

      Add(systemFactory.Create<StatusVisualsFeature>());

      Add(systemFactory.Create<UnapplyAffectedStatusesWithoutDurationSystem>());

      Add(systemFactory.Create<CleanupUnappliedStatusLinkedChanges>());
      Add(systemFactory.Create<CleanupUnappliedStatuses>());
    }
  }
}