namespace CodeBase.Runtime.Gameplay.Core
{
  public static class GameplayEntityExtensions
  {
    private static GameContext GameContext => Contexts.sharedInstance.game;

    public static GameEntity Producer(this GameEntity effect)
    {
      return effect.hasProducerId
        ? GameContext.GetEntityWithId(effect.ProducerId)
        : null;
    }

    public static bool IsNotProducer(this GameEntity entity, int targetId) =>
      entity.hasProducerId == false || entity.ProducerId != targetId;
  }
}