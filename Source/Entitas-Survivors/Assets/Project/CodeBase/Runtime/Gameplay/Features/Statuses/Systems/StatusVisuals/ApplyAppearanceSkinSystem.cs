using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems.StatusVisuals
{
  public class ApplyAppearanceSkinSystem : ReactiveSystem<GameEntity>
  {
    public ApplyAppearanceSkinSystem(GameContext gameContext) : base(gameContext)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Status.Added());

    protected override bool Filter(GameEntity entity) =>
      entity.isStatus && entity.hasTargetId && entity.hasAppearanceSkin;

    protected override void Execute(List<GameEntity> statuses)
    {
      foreach (GameEntity status in statuses)
      {
        GameEntity target = status.Target();
        if (target is { hasAppearanceVisuals: true })
        {
          target.AppearanceVisuals.ApplySkin(status.AppearanceSkin);
          target.UpdateStatusVisuals(target.AppearanceVisuals.CurrentSkin);
        }
      }
    }
  }
}