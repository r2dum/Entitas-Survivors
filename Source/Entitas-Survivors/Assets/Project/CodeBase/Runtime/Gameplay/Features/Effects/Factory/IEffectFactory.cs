namespace CodeBase.Runtime.Gameplay.Features.Effects.Factory
{
  public interface IEffectFactory
  {
    GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId);
  }
}