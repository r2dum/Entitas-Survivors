namespace CodeBase.Runtime.Gameplay.Features.Effects
{
  public static class EffectEntityExtensions
  {
    private static GameContext GameContext => Contexts.sharedInstance.game;

    public static GameEntity Target(this GameEntity effect)
    {
      return effect.hasTargetId
        ? GameContext.GetEntityWithId(effect.TargetId)
        : null;
    }
  }
}